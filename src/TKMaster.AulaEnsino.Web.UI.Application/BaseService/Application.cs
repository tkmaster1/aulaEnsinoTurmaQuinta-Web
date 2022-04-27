using Microsoft.Extensions.Configuration;

namespace TKMaster.AulaEnsino.Web.UI.Application.BaseService
{
    public class Application
    {
        #region Properties

        public string Version { get; set; }

        #endregion

        #region Constructor

        public Application()
        {
            IConfiguration _configuration = new ConfigurationBuilder()
                                                .AddJsonFile("AppSettings.json").Build();

            Version = _configuration["AppSettings:Application:Version"];
        }

        #endregion
    }
}
