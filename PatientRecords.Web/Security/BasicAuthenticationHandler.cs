using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PatientRecords.BLLayer.Extend.ExtendServices;
using PatientRecords.BLLayer.Extend.ExtendServices.Interfaces;
using PatientRecords.DataLayer.DataBasics.BasicService;
using PatientRecords.DataLayer.Data.Entities;
using AutoMapper;

namespace PatientRecords.Web.Security
{
    public class BasicAuthenticationHandler //: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //private readonly IAuthService _authService;
        //private readonly UserQueryService _userQueryService;
        //private readonly JwtService _jwtService;
        //private readonly IMapper _mapper;
 

        //public BasicAuthenticationHandler(
        //    IOptionsMonitor<AuthenticationSchemeOptions> options,
        //    ILoggerFactory logger,
        //    UrlEncoder encoder,
        //    ISystemClock clock,
        //    JwtService   jwtService,
        //    IAuthService authService,
        //    UserQueryService userQueryService,
        //    IMapper mapper)
        //    : base(options, logger, encoder, clock)
        //{
        //    _authService = authService;
        //    _userQueryService = userQueryService;
        //    _jwtService = jwtService;
        //    this._mapper = mapper;
        //}
    
        //protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        //{

        //    var endpoint = Context.GetEndpoint();

        //    if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        //        return AuthenticateResult.NoResult();

        //    if (!Request.Headers.ContainsKey("Authorization"))
        //        return AuthenticateResult.Fail("Missing Authorization Header");

        //    UserDTO currentUser = null;
        //    try
        //    {
        //        var token =  Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //        string userId =  _jwtService.ValidateJwtToken(token) ;
        //        currentUser = await _userQueryService.GetSingleWithRoles(userId);
        //    }
        //    catch(Exception ex)
        //    {
        //       return AuthenticateResult.Fail("Invalid Authorization Header");
        //    }

        //    if (currentUser == null)
        //    {
        //        return AuthenticateResult.Fail("Invalid Username or Password");
        //    }
        //    var ticket = GetAuthenticationTicket(currentUser);

        //    bool isAuthorizeUser =  CheckAuthorization(endpoint, currentUser);
        //    if (!isAuthorizeUser)
        //    {
        //        return AuthenticateResult.Fail("Invalid Authorization");
        //    }

        //    AuthorizationResult.Success();
        //    return AuthenticateResult.Success(ticket);
        //}


        //private bool CheckAuthorization(Endpoint endpoint, UserDTO currentUser)
        //{

        //    var AuthorizeAttribute = endpoint?.Metadata?.FirstOrDefault(s => s is AuthorizeAttribute) as AuthorizeAttribute;

        //    var roles = AuthorizeAttribute?.Roles?.Split(",");
        //    var polices = AuthorizeAttribute?.Policy?.Split(",");


        //    bool isAuthorizeUser = roles == null || roles?.Length == 0;
        //    List<string> currentUserRoles = currentUser?.UserRoles?.Select(s => s.Role.Name).ToList();
        //    if (roles != null && currentUserRoles!=null)
        //    {
        //        foreach (var role in roles)
        //        {
        //            if (currentUserRoles.Contains(role))
        //            {
        //                isAuthorizeUser = true;
        //                break;
        //            }
        //        }
        //    }



        //    return isAuthorizeUser;
        //}

        //private AuthenticationTicket GetAuthenticationTicket(UserDTO currentUser)
        //{
        //    List<Claim> claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimTypes.NameIdentifier, currentUser.Id.ToString()));
        //    claims.Add(new Claim(ClaimTypes.Name, currentUser.UserName));

        //    if (currentUser.UserRoles!= null)
        //    {
        //        foreach (var item in currentUser.UserRoles.ToList().Select(s => s.Role.Name))
        //        {
        //            claims.Add(new Claim(ClaimTypes.Role, item));
        //        }

        //    }

        //    var identity = new ClaimsIdentity(claims.ToArray(), Scheme.Name);
        //    var principal = new ClaimsPrincipal(identity);
        //    Context.Items["CurrentUser"] = currentUser;
        //    Context.User = principal;
        //    WebsiteContext.LoggedInUser = this._mapper.Map<User>(currentUser);  
        //    return new AuthenticationTicket(principal, Scheme.Name);

        //}
    }
}