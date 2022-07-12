using Microsoft.Extensions.DependencyInjection.Extensions;
using TKMaster.AulaEnsino.Web.UI.Application.BaseService;
using TKMaster.AulaEnsino.Web.UI.Application.BaseService.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.Services;

namespace TKMaster.AulaEnsino.Web.UI.Configurations
{
    public abstract class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Lifestyle.Transient => Uma instância para cada solicitação
            // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
            // Lifestyle.Scoped    => Uma instância única para o request

            services.AddScoped<IBaseService, BaseService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();

            services.AddTransient<IFornecedorAppService, FornecedorAppService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
