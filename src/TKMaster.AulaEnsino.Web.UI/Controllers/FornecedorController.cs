using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.ViewModels;

namespace TKMaster.AulaEnsino.Web.UI.Controllers
{
    public class FornecedorController : Controller
    {
        #region Properties       

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public FornecedorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Views

        public IActionResult Index()
        {
            ViewBag.TipoPessoa = Util.Common.PopularComboSituacaoStatus().OrderBy(x => x.Value);
            return View();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public async Task<IActionResult> Pesquisar()
        {
            //RequestBuscarFornecedor pesquisar
            var response = await _unitOfWork.FornecedorApp.ListarTodos();

            var retorno = _mapper.Map<List<FornecedorViewModel>>(response?.Data.ToList() ?? new List<FornecedorDTO>());

            return Ok(retorno);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
