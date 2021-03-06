﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.CustomMiddlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            //basic sabri:12345
            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring(6).Trim();
                var crediantalString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var crediantals = crediantalString.Split(':');
                if (crediantals[0] == "sabri" && crediantals[1] == "123456")
                {
                    var claims = new[]
                    {
                        new Claim("name",crediantals[0]),
                        new Claim(ClaimTypes.Role,"Admin"),
                    };
                    var identity = new ClaimsIdentity(claims);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
                await _next(context);

            }
        }
    }
}
