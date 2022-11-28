using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Core.Interface.Helper
{
    public interface IHttpCaller
    {
        Task<System.Net.Http.HttpResponseMessage> GetAsync<HttpResponseMessage>(string baseAddress, string ApiAddress, string AuthenticationHeaderType, string Token, string MediaType, Dictionary<string, string> cookies, Dictionary<string, string> headers);
        Task<System.Net.Http.HttpResponseMessage> PostAsync<HttpResponseMessage, Tpara>(string baseAddress, string ApiAddress, string Token, Tpara para, string AuthenticationHeaderType, string MediaType, string BodyMediaType, bool IsBodyRequestJSON, Dictionary<string, string> cookie, Dictionary<string, string> headers);
        Task<HttpResponseMessage> PutAsync<TreturnHttpResponseMessage, Tpara>(string baseAddress, string ApiAddress, string Token, Tpara para, string AuthenticationHeaderType, string MediaType, string BodyMediaType, bool IsBodyRequestJSON, Dictionary<string, string> cookies, Dictionary<string, string> headers);
        Task<HttpResponseMessage> DeleteAsync<TreturnHttpResponseMessage>(string baseAddress, string ApiAddress, string AuthenticationHeaderType, string Token, string MediaType, Dictionary<string, string> cookies, Dictionary<string, string> headers);
        Task<HttpResponseMessage> PostUploadFileAsync<ThttpResponseMessage, Tpara>(string baseAddress, string ApiAddress, string Token, Tpara para, string AuthenticationHeaderType, string MediaType, string BodyMediaType, bool IsBodyRequestJSON, Dictionary<string, string> cookies, Dictionary<string, string> headers);
    }
}
