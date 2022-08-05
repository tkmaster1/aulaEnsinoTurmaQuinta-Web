using TKMaster.AulaEnsino.Web.UI.Application.BaseService.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.Application.Response;

namespace TKMaster.AulaEnsino.Web.UI.Application.Services
{
    public class FornecedorAppService : IFornecedorAppService
    {
        #region Properties

        private readonly IBaseService _baseService;

        #endregion

        #region Constructor

        public FornecedorAppService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #endregion

        #region Methods

        public async Task<RetornoAPIData<object>> Adicionar(RequestFornecedor req)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/Adicionar/";

            var request = _baseService.MontarRequest("POST", url, req);

            return await _baseService.MontarResponse<object>(request);
        }

        public async Task<RetornoAPIData<object>> Atualizar(RequestFornecedor requestAtualizar)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/Atualizar/";

            var request = _baseService.MontarRequest("PUT", url, requestAtualizar);

            return await _baseService.MontarResponse<object>(request);
        }

        public async Task<RetornoAPIData<object>> Deletar(RequestExcluirReativarFornecedor req)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/Excluir/";

            var request = _baseService.MontarRequest("PUT", url, req);

            return await _baseService.MontarResponse<object>(request);
        }

        public async Task<RetornoAPIData<object>> Reativar(RequestExcluirReativarFornecedor req)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/Reativar/";

            var request = _baseService.MontarRequest("PUT", url, req);

            return await _baseService.MontarResponse<object>(request);
        }

        public async Task<RetornoAPIData<FornecedorDTO>> NomeExiste(string nomeFornecedor)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/NomeExiste/{nomeFornecedor}";

            var request = _baseService.MontarRequest("GET", url);

            return await _baseService.MontarResponse<FornecedorDTO>(request);
        }

        public async Task<RetornoAPIData<FornecedorDTO>> DocumentoExiste(string documento)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/DocumentoExiste/{documento}";

            var request = _baseService.MontarRequest("GET", url);

            var response = await _baseService.MontarResponse<FornecedorDTO>(request);

            return response;
        }

        public async Task<RetornoAPIDataList<FornecedorDTO>> ListarTodos()
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/ListarTodos";

            var request = _baseService.MontarRequest("GET", url);

            return await _baseService.MontarResponseList<FornecedorDTO>(request);
        }

        public async Task<RetornoAPIData<FornecedorDTO>> ObterPorCodigo(int codigo)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/ObterPorCodigo/{codigo}";

            var request = _baseService.MontarRequest("GET", url);

            return await _baseService.MontarResponse<FornecedorDTO>(request);
        }

        public async Task<RetornoAPIDataList<FornecedorDTO>> BuscarFornecedores(RequestBuscarFornecedor requestBuscar)
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/BuscarFornecedores";

            var request = _baseService.MontarRequest("POST", url, requestBuscar);

            return await _baseService.MontarResponseList<FornecedorDTO>(request);
        }

        #endregion
    }
}
