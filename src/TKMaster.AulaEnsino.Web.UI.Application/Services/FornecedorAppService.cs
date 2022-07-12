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

        public Task<RetornoAPIData<object>> Adicionar(RequestAdicionarFornecedor req)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoAPIData<object>> Atualizar(RequestAtualizarFornecedor req)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoAPIData<object>> Deletar(RequestExcluirReativarFornecedor req)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoAPIData<FornecedorDTO>> DocumentoExiste(string documento)
        {
            throw new NotImplementedException();
        }

        public async Task<RetornoAPIDataList<FornecedorDTO>> ListarTodos()
        {
            string url = $"{_baseService.UrlBase}/Fornecedor/ListarTodos";

            var request = _baseService.MontarRequest("GET", url);

            return await _baseService.MontarResponseList<FornecedorDTO>(request);
        }

        public Task<RetornoAPIData<FornecedorDTO>> NomeExiste(string nomeFornecedor)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoAPIData<FornecedorDTO>> ObterPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoAPIData<object>> Reativar(RequestExcluirReativarFornecedor req)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
