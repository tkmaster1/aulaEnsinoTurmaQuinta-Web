using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.Application.Response;

namespace TKMaster.AulaEnsino.Web.UI.Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Task<RetornoAPIDataList<FornecedorDTO>> ListarTodos();

        Task<RetornoAPIData<FornecedorDTO>> ObterPorCodigo(int codigo);

        Task<RetornoAPIData<object>> Adicionar(RequestFornecedor req);

        Task<RetornoAPIData<object>> Atualizar(RequestFornecedor req);

        Task<RetornoAPIData<object>> Deletar(RequestExcluirReativarFornecedor req);

        Task<RetornoAPIData<object>> Reativar(RequestExcluirReativarFornecedor req);

        Task<RetornoAPIData<FornecedorDTO>> NomeExiste(string nomeFornecedor);

        Task<RetornoAPIData<FornecedorDTO>> DocumentoExiste(string documento);
    }
}
