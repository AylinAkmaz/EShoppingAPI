using System.Net;
using System.Threading.Tasks;
using EShoppingAPI.Entity.Result;
using EShoppingAPI.Helper.CustomException;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace EShoppingAPI.Apı.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    //public class GlobalExceptionMiddleware
    //{
    //    private readonly RequestDelegate _next;

    //    public GlobalExceptionMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    public async Task InvokeAsync(HttpContext httpContext)
    //    {
    //        try
    //        {
    //            await _next(httpContext);
    //        }
    //        catch (Exception e)
    //        {
    //            if (e.GetType() == typeof(FieldValidationException))
    //            {
    //                List<string>? errors = e.Data["FieldValidationError"] as List<string>;

    //                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<FieldValidationException>.FieldValidationError(errors));
    //            }
    //            else if (e.GetType() == typeof(SecurityTokenSignatureKeyNotFoundException))
    //            {
    //                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<FieldValidationException>.TokenError(HataBilgisi.TokenError()));

    //            }
    //            else if (e.GetType() == typeof(SecurityTokenInvalidSignatureException))
    //            {
    //                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<FieldValidationException>.TokenError(HataBilgisi.TokenError()));
    //            }
    //            else if (e.GetType() == typeof(SecurityTokenInvalidSignatureException))
    //            {
    //                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<FieldValidationException>.TokenError(HataBilgisi.TokenError()));
    //            }
    //            else if (e.GetType() == typeof(SecurityTokenValidationException))
    //            {
    //                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<FieldValidationException>.TokenError(HataBilgisi.TokenError()));
    //            }

    //            else if (e.GetType() == typeof(TokenNotFoundException))
    //            {
    //                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<FieldValidationException>.TokenNotFoundError(HataBilgisi.TokenNotFoundError()));

    //            }
    //            else
    //            {
    //                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //                httpContext.Response.ContentType = "application/json";
    //                await httpContext.Response.WriteAsJsonAsync(Sonuç<bool>.Error(HataBilgisi.Error()));
    //            }

    //        }


    //    }
    //}

    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class GlobalExceptionMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    //    }
    //}
}
