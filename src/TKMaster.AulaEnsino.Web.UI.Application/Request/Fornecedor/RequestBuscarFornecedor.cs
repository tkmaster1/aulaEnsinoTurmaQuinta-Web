namespace TKMaster.AulaEnsino.Web.UI.Application.Request.Fornecedor
{
    public class RequestBuscarFornecedor
    {
        public int? Codigo { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        public string StatusPesquisa { get; set; }
    }
}
