using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TKMaster.AulaEnsino.Web.UI.Application.BaseService;
using TKMaster.AulaEnsino.Web.UI.Configurations.Filters;

namespace TKMaster.AulaEnsino.Web.UI.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllersWithViews(o =>
            {
                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddControllers(opt => opt.Filters.Add(typeof(CustomActionFilterConfig)));

            services.AddRazorPages();

            var appConfig = configuration.GetSection("AppSettings").Get<ApplicationConfig>();
            services.AddSingleton(appConfig);
            services.Configure<ApplicationConfig>(configuration.GetSection("AppSettings"));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddCors();

            return services;
        }
    }
}
