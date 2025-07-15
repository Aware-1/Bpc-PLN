using BPC_PLN_SPA.Components.Layout;
using BPC_PLN_SPA.Service;
using Data.Context;
using Data.Reposirory;
using Domain.IRipository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BPC_PLN_SPA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            #region IOC
            builder.Services.AddCascadingAuthenticationState();
            //builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddSingleton<IReposiroryCharge, ReposiroryCharge>();
            builder.Services.AddSingleton<IDispatchRipository, DispatchRipository>();
            builder.Services.AddHttpContextAccessor();




            builder.Services.AddDbContext<BpcwebserverDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationServices")));

            builder.Services.AddDbContext<UnityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("UnityConnectionString")));

            
/*            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login"; 
                });
            //builder.Services.AddHttpContextAccessor();
*/

            #endregion

           // builder.Services.AddAuthorization();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            app.Run();
        }
    }
}
