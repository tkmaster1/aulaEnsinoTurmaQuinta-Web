using Microsoft.AspNetCore.Http;
using TKMaster.AulaEnsino.Web.UI.Application.BaseService.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.Interfaces;

namespace TKMaster.AulaEnsino.Web.UI.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private readonly IBaseService _baseService;
        private readonly IHttpContextAccessor _context;

        #endregion

        #region Constructor

        public UnitOfWork(IBaseService baseService,
                          IHttpContextAccessor context)
        {
            _baseService = baseService;
            _context = context;
        }

        #endregion

        #region Instâncias Privadas

        private IFornecedorAppService _fornecedorApp;

        #endregion

        #region Instancias Publicas

        public IFornecedorAppService FornecedorApp => _fornecedorApp ?? new FornecedorAppService(_baseService);

        #endregion
    }
}
