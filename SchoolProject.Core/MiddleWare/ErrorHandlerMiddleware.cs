using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using System.Net;
using System.Text.Json;
namespace SchoolProject.Core.MiddleWare
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //RequestDelegate next means go to the next middleware in the pipeline

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //method will take the request and handle it
        public async Task Invoke(HttpContext context)
        {
            try
            {
                //RequestDelegate next means go to the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                Response<string> responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };
                //TODO:: cover all validation errors
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        // custom application error
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case ValidationException e:
                        // custom validation error
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        responseModel.Message = error.Message; ;
                        responseModel.StatusCode = HttpStatusCode.NotFound;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;



                    case DbUpdateException e:
                        // can't update error
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Exception e:
                        if (e.GetType().ToString() == "ApiException")
                        {
                            responseModel.Message += e.Message;
                            responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;
                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        responseModel.Message = e.Message;
                        responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;

                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    default:
                        // unhandled error
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                string result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }


}
