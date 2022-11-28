//using ENIMS.Common;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
//using System.Web.Mvc;

//namespace ENIMS.Api
//{

//    public class ValidationFailedResult : ObjectResult
//    {
//        public ValidationFailedResult(ModelStateDictionary modelState)
//            : base(new ValidationResultModel(modelState))
//        {
//            StatusCode = StatusCodes.Status422UnprocessableEntity;
//        }
//    }

//    public class ValidateModelAttribute : System.Web.Http.Filters.ActionFilterAttribute
//    {
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            if (actionContext.ModelState.IsValid == false)
//            {
//                actionContext.Response = actionContext.Request.CreateErrorResponse(
//                    HttpStatusCode.BadRequest, actionContext.ModelState);
//            }
//        }
//    }

//    public class ValidationResultModel : OperationStatusResponse
//    {
//        public ValidationResultModel(ModelStateDictionary modelState)
//        {
//            Message = Resources.ValidationFailed;
//            Errors = modelState.Keys
//                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
//                    .ToList();
//        }
//        public ValidationResultModel()
//        {

//        }
//    }

//}
