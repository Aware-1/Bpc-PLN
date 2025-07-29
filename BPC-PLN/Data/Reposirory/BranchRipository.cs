using Data.Context;
using Domain.Dtos;
using Domain.IRipository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Data.Reposirory
{
    public class BranchRipository : IBranchRipository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UnityDbContext _contextUnity;
        private readonly BpcwebserverDbContext _contextPoral;

        public BranchRipository(IHttpContextAccessor httpContextAccessor, BpcwebserverDbContext bpcwebserverDbContext, UnityDbContext contextUnity)
        {
            _httpContextAccessor = httpContextAccessor;
            _contextUnity = contextUnity;
            _contextPoral = bpcwebserverDbContext;
        }

        public string? GetUserName()
        {
            var token = GetToken();
            return token?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }

      

        private JwtSecurityToken? GetToken()
        {
            var accessToken = _httpContextAccessor.HttpContext?.Request.Cookies["access_token"];
            if (string.IsNullOrWhiteSpace(accessToken))
                return null;

            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(accessToken);
        }


        public async Task<HeaderBranchDto?> GetHeaderAsync(string userName)
        {
            var persian = new CultureInfo("fa-IR");
            persian.DateTimeFormat.Calendar = new PersianCalendar();
            var now = DateTime.Now;

            var userInfo = await _contextUnity.BranchUsers
                .Where(u => u.UserName.Trim() == userName.Trim())
                .Select(u => new HeaderBranchDto
                {
                    Date = now,
                    RequestCode = u.BranchCode + now.ToString("yyMMddHHmms", persian),
                    Address = u.Addr1,
                    Address2 = u.Addr2,
                    DeliveryPlace = u.Code,
                    Definition = u.Definition_,
                    BranchName = u.Name,
                    WareCode = u.WareCode,
                    BranchCode = u.BranchCode,
                })
                .FirstOrDefaultAsync();

            if (userInfo == null) return null;

            return userInfo;
        }

    }
}
