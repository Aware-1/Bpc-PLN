using BPC_PLN_SPA.Services;
using Data.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BPC_PLN_SPA.Service;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly UnityDbContext _unityDb;
    private readonly BpcwebserverDbContext _bpcwebserverDb;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthStateProvider(UnityDbContext unityDb, BpcwebserverDbContext bpcwebserverDb, IHttpContextAccessor httpContextAccessor)
    {
        _unityDb = unityDb;
        _bpcwebserverDb= bpcwebserverDb;
        _httpContextAccessor = httpContextAccessor;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            if (_httpContextAccessor.HttpContext!.Request.Cookies.ContainsKey(BlazorConstants.AuthCookieName))
            {
                var token = _httpContextAccessor.HttpContext.Request.Cookies[BlazorConstants.AuthCookieName];
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
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

    public string Login(LoginBranchDto model)
    {
        bool success = false;
        string role = "";
        BranchUser branchUser = new();
        BranchUser providerUser = new();

        if (model is not null)
        {
            switch (model.AccessType)
            {
                case DbAccessType.Branch:

                    branchUser = _unityDb.BranchUsers.FirstOrDefault(u =>
                         u.UserName.Trim() == model.Username.Trim() &&
                         u.Password.Trim() == model.Password.Trim());


                    if (branchUser != null)
                    {
                        success = true;
                        role = "Branch";
                    }

                    break;
                case DbAccessType.Provider:
                    var user = _bpcwebserverDb.ProviderUsers.FirstOrDefault(u =>
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
                string area = (role == "Branch" ? branchUser.BranchCode : providerUser.BranchCode).ToString();

                var claimsIdentity = new ClaimsIdentity(
                    [
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("Code",area),

                    ]);

                // generate a JWT token based on the claims
                var token = new JwtSecurityToken(
                    issuer: "https://test-issuer.com",
                    audience: Guid.NewGuid().ToString(),
                    claims: claimsIdentity.Claims,
                    expires: DateTime.Now.AddMinutes(30),
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

