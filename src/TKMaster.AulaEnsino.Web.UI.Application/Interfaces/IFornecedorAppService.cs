using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.Application.Response;

namespace TKMaster.AulaEnsino.Web.UI.Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Task<RetornoAPIDataList<ForcenedorDTO>> ListarTodos();

        Task<RetornoAPIData<ForcenedorDTO>> ObterPorCodigo(int codigo);

        Task<RetornoAPIData<object>> Adicionar(RequestAdicionarFornecedor req);

        Task<RetornoAPIData<object>> Atualizar(RequestAtualizarFornecedor req);

        Task<RetornoAPIData<object>> Deletar(RequestExcluirReativarFornecedor req);

        Task<RetornoAPIData<object>> Reativar(RequestExcluirReativarFornecedor req);

        Task<RetornoAPIData<ForcenedorDTO>> NomeExiste(string nomeFornecedor);

        Task<RetornoAPIData<ForcenedorDTO>> DocumentoExiste(string documento);
    }
}
