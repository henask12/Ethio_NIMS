using ENIMS.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common
{
    public static class FileUploadHelper
    {
        // Get the default form options so that we can use them to set the default 
        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public static async Task<UploadProcessResponse> ProcessUpload
            (Stream stream,
             StringSegment input,
             string contentType,
             string[] _permittedExtensions,
             long _fileSizeLimit,
             string _targetFilePath)
        {
            try
            {
                ModelStateDictionary modelState = new ModelStateDictionary();
                if (!MultipartRequestHelper.IsMultipartContentType(contentType)) // Log error
                    return new UploadProcessResponse { Message = Resources.RequestCouldntBeProcessed, Status = OperationStatus.ERROR };

                // Accumulate the form data key-value pairs in the request (formAccumulator).
                var formAccumulator = new KeyValueAccumulator();
                string fileName = String.Empty;

                var boundary = MultipartRequestHelper.GetBoundary(
                    MediaTypeHeaderValue.Parse(input),
                    _defaultFormOptions.MultipartBoundaryLengthLimit);

                var reader = new MultipartReader(boundary, stream);
                var section = await reader.ReadNextSectionAsync();

                while (section != null)
                {
                    var hasContentDispositionHeader =
                        ContentDispositionHeaderValue.TryParse(
                            section.ContentDisposition, out var contentDisposition);

                    if (hasContentDispositionHeader)
                    {
                        if (MultipartRequestHelper
                            .HasFormDataContentDisposition(contentDisposition))
                        {
                            // Don't limit the key name length because the 
                            // multipart headers length limit is already in effect.
                            var key = HeaderUtilities
                                .RemoveQuotes(contentDisposition.Name).Value;
                            var encoding = GetEncoding(section);

                            if (encoding == null)
                            {
                                // Log error
                                return new UploadProcessResponse
                                {
                                    Message = Resources.RequestCouldntBeProcessed,
                                    Status = OperationStatus.ERROR,
                                };
                            }

                            using (var streamReader = new StreamReader(
                                section.Body,
                                encoding,
                                detectEncodingFromByteOrderMarks: true,
                                bufferSize: 1024,
                                leaveOpen: true))
                            {
                                // The value length limit is enforced by 
                                // MultipartBodyLengthLimit
                                var value = await streamReader.ReadToEndAsync();

                                if (string.Equals(value, "undefined",
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    value = string.Empty;
                                }

                                formAccumulator.Append(key, value);

                                if (formAccumulator.ValueCount >
                                    _defaultFormOptions.ValueCountLimit)
                                {
                                    // Form key count limit of 
                                    // _defaultFormOptions.ValueCountLimit 
                                    // is exceeded.

                                    // Log error
                                    return new UploadProcessResponse
                                    {
                                        Message = Resources.RequestCouldntBeProcessed,
                                        Status = OperationStatus.ERROR
                                    };
                                }
                            }
                        }
                        else if (MultipartRequestHelper
                            .HasFileContentDisposition(contentDisposition))
                        {
                            // Don't trust the file name sent by the client. To display
                            // the file name, HTML-encode the value.
                            var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                                    contentDisposition.FileName.Value);
                            var trustedFileNameForFileStorage = Path.GetRandomFileName();

                            //get ext
                            var ext = Path.GetExtension(trustedFileNameForDisplay).ToLowerInvariant();

                            if (string.IsNullOrEmpty(ext))// Log error
                                return new UploadProcessResponse { Message = Resources.RequestCouldntBeProcessed, Status = OperationStatus.ERROR };

                            trustedFileNameForFileStorage = trustedFileNameForFileStorage + ext;
                            fileName = trustedFileNameForFileStorage;

                            var streamedFileContent = await FileHelpers.ProcessStreamedFile(
                                section, contentDisposition, modelState,
                                _permittedExtensions, _fileSizeLimit);

                            if (!modelState.IsValid)//
                                return new UploadProcessResponse { Message = Resources.FileUploadError, MessageList = MapError(modelState), Status = OperationStatus.ERROR };

                            using (var targetStream = File.Create(
                                Path.Combine(_targetFilePath, trustedFileNameForFileStorage)))
                            {
                                await targetStream.WriteAsync(streamedFileContent);
                                // Log
                            }
                        }
                        else// Log error
                            return new UploadProcessResponse { Message = Resources.RequestCouldntBeProcessed, Status = OperationStatus.ERROR };
                    }
                    // Drain any remaining section body that hasn't been consumed and
                    // read the headers for the next section.
                    section = await reader.ReadNextSectionAsync();
                }
                return new UploadProcessResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS, FileName = fileName, formAccumulator = formAccumulator };

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static Encoding GetEncoding(MultipartSection section)
        {
            var hasMediaTypeHeader =
                MediaTypeHeaderValue.TryParse(section.ContentType, out var mediaType);

            // UTF-7 is insecure and shouldn't be honored. UTF-8 succeeds in 
            // most cases.
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
            {
                return Encoding.UTF8;
            }

            return mediaType.Encoding;
        }

        private static List<string> MapError(ModelStateDictionary modelState)
        {
            List<string> error = new List<string>();

            foreach (var model in modelState)
            {
                foreach (var err in model.Value.Errors)
                {
                    error.Add(err.ErrorMessage);
                }

            }
            return error;
        }
    }

    public static class FileUploader
    {
        public  static FileUploadResult Upload(IFormFile file, string basePath, string projectId,long fileSizeLimit)
        {
            try
            {
                if (file != null && file.Length>0)
                {
                    var filename = file.FileName;
                    if (!Directory.Exists(basePath))
                        Directory.CreateDirectory(basePath);
                    using (var stream = new FileStream(basePath + "/" + file.FileName, FileMode.Create))
                    {
                        if (file.Length <= fileSizeLimit)
                            file.CopyToAsync(stream);
                        return new FileUploadResult
                        {
                            Path = file.FileName,
                            Result = true,
                        };
                    }
                }
                else
                {
                    return new FileUploadResult
                    {
                        Path =null,
                        Result = true,
                    };
                }
                
            }
            catch (Exception ex)
            {
                return new FileUploadResult
                {
                    Path = "",
                    Result = true,
                };
            }
        }

    }
}
