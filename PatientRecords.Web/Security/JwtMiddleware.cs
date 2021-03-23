using PatientRecords.BLLayer.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PatientRecords.BLLayer.Extends.ExtendServices;

namespace PatientRecords.Web.Security
{
    public class JwtMiddleware
    {
        //private readonly RequestDelegate _next;
        //private   JwtService _jwtService;
        //private   UserQueryService _usserQueryService;

        //public JwtMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        
        //}

        //public async Task Invoke(HttpContext context, JwtService jwtService, UserQueryService usserQueryService)
        //{
        //    _jwtService = jwtService;
        //    _usserQueryService = usserQueryService;
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    if (token != null)
        //        await attachCurrentUserToContext(context, token);

        //    await _next(context);
        //}

        //private async Task attachCurrentUserToContext(HttpContext context, string token)
        //{
        //    try
        //    {

        //        string currentUseId =_jwtService.ValidateJwtToken(token);
        //        var currentUser = await _usserQueryService.GetSingle(currentUseId);
        //        var userRule = currentUser.UserName;
        //        var userName = currentUser.UserName;
        //        var claims = new[]
        //        {
        //            new Claim("name", userName),
        //            new Claim(ClaimTypes.Role, userRule),
        //        };
        //        var identity = new ClaimsIdentity(claims, "basic");
        //        context.User = new ClaimsPrincipal(identity); 
        //        context.Items["CurrentUser"] = currentUser;
        //    }
        //    catch
        //    {
                 
        //    }
        //}
    }
}
