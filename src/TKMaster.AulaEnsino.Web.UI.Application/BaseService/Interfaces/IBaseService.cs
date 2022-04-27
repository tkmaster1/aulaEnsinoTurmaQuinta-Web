using TKMaster.AulaEnsino.Web.UI.Application.Response;

namespace TKMaster.AulaEnsino.Web.UI.Application.BaseService.Interfaces
{
    public interface IBaseService
    {
        #region Properties

        string UrlBase { get; }

        #endregion

        #region Methods

        string MontarParametros(string[] parametros);

        HttpRequestMessage MontarRequest(string metodo, string url, object parametros = null);

        Task<RetornoAPIData<T>> MontarResponse<T>(HttpRequestMessage request) where T : class;

        Task<RetornoAPIData<KeyValuePair<object, string>>> MontarResponseRegraNegocio<T>(HttpRequestMessage request);

        Task<RetornoAPIDataList<T>> MontarResponseList<T>(HttpRequestMessage request) where T : class;


        #endregion
    }
}
