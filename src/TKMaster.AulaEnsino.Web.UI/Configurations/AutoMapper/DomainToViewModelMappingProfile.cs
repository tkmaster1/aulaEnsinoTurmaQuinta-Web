using AutoMapper;
using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.ViewModels;

namespace TKMaster.AulaEnsino.Web.UI.Configurations.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Fornecedor
            CreateMap<FornecedorDTO, FornecedorViewModel>();
            CreateMap<RequestFornecedor, FornecedorViewModel>();

        }
    }
}
