using AutoMapper;
using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.ViewModels;

namespace TKMaster.AulaEnsino.Web.UI.Configurations.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // Fornecedor
            CreateMap<FornecedorViewModel, FornecedorDTO>();
            CreateMap<FornecedorViewModel, RequestFornecedor>();
        }
    }
}
