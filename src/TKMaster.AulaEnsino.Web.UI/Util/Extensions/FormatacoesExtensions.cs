namespace TKMaster.AulaEnsino.Web.UI.Util.Extensions
{
    public static class FormatacoesExtensions
    {
        public static string FormataStatus(bool status)
        {
            return status ? "Ativo" : "Inativo";
        }

        public static string FormataTipoPessoa(string tipoPessoa)
        {
            return tipoPessoa == "F" ? "Física" : "Jurídica";
        }

        public static string FormataDocumento(string tipoPessoa, string documento)
        {
            return tipoPessoa == "F" ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
