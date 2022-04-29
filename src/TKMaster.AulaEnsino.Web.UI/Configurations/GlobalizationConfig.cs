using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace TKMaster.AulaEnsino.Web.UI.Configurations
{
    public static class GlobalizationConfig
    {
        public static IApplicationBuilder UseGlobalizationConfig(this IApplicationBuilder builder)
        {
            var defaultCulture = new CultureInfo("pt-BR");

            var localizationOptions = new RequestLocalizationOptions
            {

                DefaultRequestCulture  = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            builder.UseRequestLocalization(localizationOptions);

            return builder;
        }
    }
}
