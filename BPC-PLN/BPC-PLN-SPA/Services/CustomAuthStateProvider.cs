using Data.Context;
using Domain.Dtos;
using Domain.Entities.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BPC_PLN_SPA.Service;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public const string AuthCookieName = "access_token";


    private readonly UnityDbContext _unityDb;
    private readonly BpcwebserverDbContext _bpcwebserverDb;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthStateProvider(UnityDbContext unityDb, BpcwebserverDbContext bpcwebserverDb, IHttpContextAccessor httpContextAccessor)
    {
        _unityDb = unityDb;
        _bpcwebserverDb = bpcwebserverDb;
        _httpContextAccessor = httpContextAccessor;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            if (_httpContextAccessor.HttpContext!.Request.Cookies.ContainsKey(AuthCookieName))
            {
                var token = _httpContextAccessor.HttpContext.Request.Cookies[AuthCookieName];
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                string? expDate = jsonToken?.Claims?.Where(x => x.Type == "exp").FirstOrDefault()?.Value;
                if(DateTimeOffset.FromUnixTimeSeconds(int.Parse(expDate)).Date < DateTime.Now)
                {
                    return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
                }


                var claims = new List<Claim>();
                foreach (var claim in jsonToken!.Claims)
                {
                    claims.Add(new Claim(claim.Type, claim.Value));
                }

                var claimsIdentity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(claimsIdentity);
                return Task.FromResult(new AuthenticationState(user));
            }
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
        catch (Exception)
        {
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
    }

    public string Login(LoginDto model)
    {
        bool success = false;
        string role = "";
        LoginBranchUser branchUser = new();
        BranchUser providerUser = new();

        if (model is not null)
        {
            switch (model.AccessType)
            {
                case DbAccessType.Branch:

                    branchUser = _bpcwebserverDb.LoginBranchUsers.FirstOrDefault(u =>
                         u.UserName.Trim() == model.Username.Trim() &&
                         u.Password.Trim() == model.Password.Trim());


                    if (branchUser != null)
                    {
                        success = true;
                        role = "Branch";
                    }
                    break;
                case DbAccessType.Provider:
                    var user = _bpcwebserverDb.LoginProviderUsers.FirstOrDefault(u =>
                        u.Username.Trim() == model.Username.Trim() &&
                        u.Password.Trim() == model.Password.Trim());

                    if (user != null)
                    {
                        success = true;
                        role = "Provider";
                    }
                    break;
                case DbAccessType.Main:
                    //todo switch case role

                    // if (user != null)
                    //{
                    success = true;
                    role = "Main";
                    //}
                    break;
            }


            if (success)
            {
                var claimsIdentity = new ClaimsIdentity(
                    [
                    new Claim(ClaimTypes.Name, model.Username),
                    ]);

                // generate a JWT token based on the claims
                var token = new JwtSecurityToken(
                    issuer: "https://test-issuer.com",
                    audience: Guid.NewGuid().ToString(),
                    claims: claimsIdentity.Claims,
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),
                    SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }
            throw new Exception("کاربر یافت نشد");
        }

        throw new Exception("ورودی ها را پر کنید");
    }
}

