using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TKMaster.AulaEnsino.Web.UI.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int? Codigo { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "* O campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
        [DisplayName("CPF / CNPJ:")]
        public string Documento { get; set; }

        [DisplayName("Tipo Pessoa:")]
        [Required(ErrorMessage = "* O campo {0} é obrigatório")]
        public string TipoPessoa { get; set; }

        [DisplayName("Status:")]
        public bool Status { get; set; }

        public Dictionary<string, string> ListaTipoPessoa { get; set; }

        public string Mensagem { get; set; }

        //[NotMapped]
        //public string StatusPesquisa { get; set; }

        //[NotMapped]
        //public string DocumentoFormatado
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Documento))
        //        {
        //            var doc = Util.ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(Documento);

        //            return Util.Extensions.FormatacoesExtensions.FormataDocumento(TipoPessoa, doc);
        //        }

        //        return string.Empty;
        //    }
        //}

        //[NotMapped]
        //public string StatusFormatado
        //{
        //    get
        //    {
        //        return Util.Extensions.FormatacoesExtensions.FormataStatus(Status);
        //    }
        //}

        //[NotMapped]
        //public string TipoPessoaFormatado
        //{
        //    get
        //    {
        //        return Util.Extensions.FormatacoesExtensions.FormataTipoPessoa(TipoPessoa);
        //    }
        //}
    }
}
