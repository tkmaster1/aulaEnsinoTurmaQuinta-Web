using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKMaster.AulaEnsino.Web.UI.Application.DTO;
using TKMaster.AulaEnsino.Web.UI.Application.Interfaces;
using TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor;
using TKMaster.AulaEnsino.Web.UI.Util;
using TKMaster.AulaEnsino.Web.UI.Util.Extensions;
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
            ViewBag.TipoPessoa = Util.Common.PopularComboTipoPessoa().OrderBy(x => x.Value);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TipoPessoa = Util.Common.PopularComboTipoPessoa().OrderBy(x => x.Value);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedor)
        {
            string Mensagem;

            var nomeExiste = await _unitOfWork.FornecedorApp.NomeExiste(fornecedor.Nome);
            if (nomeExiste.Data != null)
            {
                Mensagem = Mensagens.MSG_NOME_FORNECEDOR.ToFormat(fornecedor.Nome);
                return Json(new { success = false, mensagem = Mensagem });
            }

            if (!string.IsNullOrEmpty(fornecedor.Documento))
            {
                var cpfcnpj = ValidarCPFCNPJ(ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(fornecedor.Documento));

                if (!string.IsNullOrEmpty(cpfcnpj))
                {
                    return Json(new { success = false, mensagem = cpfcnpj });
                }
                else
                {
                    cpfcnpj = ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(fornecedor.Documento);
                    var documentoExiste = await _unitOfWork.FornecedorApp.DocumentoExiste(cpfcnpj);
                    if (documentoExiste.Data != null)
                    {
                        Mensagem = Mensagens.MSG_DOCUMENTO_FORNECEDOR.ToFormat(fornecedor.Documento);
                        return Json(new { success = false, mensagem = Mensagem });
                    }

                    fornecedor.Documento = cpfcnpj;
                }
            }
            else
            {
                Mensagem = "CPF / CNPJ não pode ser vazio.";
                return Json(new { success = false, mensagem = Mensagem });
            }

            var fornecedorDomain = _mapper.Map<FornecedorViewModel, RequestFornecedor>(fornecedor);
            var response = await _unitOfWork.FornecedorApp.Adicionar(fornecedorDomain);

            Mensagem = response?.Data.ToString().Length <= 0
               ? Mensagens.MSG_FALHA.ToFormat("Incluir", "o Fornecedor")
               : Mensagens.MSG_SUCESSO.ToFormat("realizada", "Inclusão");

            return Json(new { success = true, mensagem = Mensagem });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await ObterFornecedor(id);
            if (fornecedor == null) { return NotFound(); }

            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FornecedorViewModel fornecedorView)
        {
            string Mensagem;

            var cpfcnpj = ValidarCPFCNPJ(ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(fornecedorView.Documento));
            if (!string.IsNullOrEmpty(cpfcnpj))
            {
                return Json(new { success = false, mensagem = cpfcnpj });
            }
            else
            {
                if (fornecedorView.Documento.Equals(@"00.000.000/0000-00"))
                {
                    Mensagem = Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CNPJ");
                    return Json(new { success = false, mensagem = Mensagem });
                }
            }

            fornecedorView.Documento = ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(fornecedorView.Documento);

            var fornecedorRequest = _mapper.Map<RequestFornecedor>(fornecedorView);
            var response = await _unitOfWork.FornecedorApp.Atualizar(fornecedorRequest);

            Mensagem = response?.Data.ToString().Length <= 0
               ? Mensagens.MSG_FALHA.ToFormat("Editar", "o Fornecedor")
               : Mensagens.MSG_SUCESSO.ToFormat("realizada", "Edição");

            return Json(new { success = true, mensagem = Mensagem });
        }

        [HttpGet]
        public async Task<IActionResult> Detalhe(int id)
        {
            var fornecedor = await ObterFornecedor(id);
            if (fornecedor == null) { return NotFound(); }

            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int id)
        {
            string Mensagem;
            var response = await _unitOfWork.FornecedorApp.Deletar(
                new RequestExcluirReativarFornecedor()
                {
                    Codigo = id
                });

            if (!(bool)response.Data)
                Mensagem = Mensagens.MSG_FALHA.ToFormat("excluir", "o Fornecedor");
            else
                Mensagem = Mensagens.MSG_SUCESSO.ToFormat("excluído", "Fornecedor");

            return Json(new { success = true, mensagem = Mensagem });
        }

        [HttpGet]
        public async Task<IActionResult> Reativar(int id)
        {
            string Mensagem;
            var response = await _unitOfWork.FornecedorApp.Reativar(
                new RequestExcluirReativarFornecedor()
                {
                    Codigo = id
                });

            if (!(bool)response.Data)
                Mensagem = Mensagens.MSG_FALHA.ToFormat("reativar", "o Fornecedor");
            else
                Mensagem = Mensagens.MSG_SUCESSO.ToFormat("reativado", "Fornecedor");

            return Json(new { success = true, mensagem = Mensagem });
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

        private static string ValidarCPFCNPJ(string cpfcnpj)
        {
            if (cpfcnpj.Length == 11)
            {
                if (!ValidationCPFCNPJ.ValidaCPF(cpfcnpj))
                    return Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CPF");
            }
            else
            {
                if (!ValidationCPFCNPJ.ValidaCNPJ(cpfcnpj))
                    return Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CNPJ");
            }

            return string.Empty;
        }

        private async Task<FornecedorViewModel> ObterFornecedor(int id)
        {
            var response = await _unitOfWork.FornecedorApp.ObterPorCodigo(id);

            var fornecedorView = _mapper.Map<FornecedorDTO, FornecedorViewModel>(response?.Data ?? new FornecedorDTO());

            fornecedorView.ListaTipoPessoa = Util.Common.PopularComboTipoPessoa();

            return fornecedorView;

        }

        #endregion
    }
}
