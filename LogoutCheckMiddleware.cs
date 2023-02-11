using FoodDeliveryAPI.Services;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;
using FoodDeliveryAPI.Models.DTOs;

namespace FoodDeliveryAPI {
    public class LogoutCheckMiddleware {
        private readonly RequestDelegate _next;

        public LogoutCheckMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICacheService cacheService) {
            if (!context.Request.Headers["Authorization"].IsNullOrEmpty()) {
                if (await cacheService.CheckToken(context.Request.Headers["Authorization"])) {
                    context.Response.Clear();
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.WriteAsJsonAsync(new Response((int)HttpStatusCode.Unauthorized, "Unauthorized. Token is disabled."));
                } else {
                    // Call the next delegate/middleware in the pipeline.
                    await _next(context);
                }
            } else {
                // Call the next delegate/middleware in the pipeline.
                await _next(context);
            }
        }
    }
    public static class LogoutCheckMiddlewareExtensions {
        public static IApplicationBuilder UseLogoutCheck(
            this IApplicationBuilder builder) {
            return builder.UseMiddleware<LogoutCheckMiddleware>();
        }
    }
}
