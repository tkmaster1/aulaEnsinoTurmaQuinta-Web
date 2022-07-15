namespace TKMaster.AulaEnsino.Web.UI.Util
{
    public static class Common
    {
        public static Dictionary<int, string> PopularComboSituacaoStatus()
        {
            return new Dictionary<int, string>
            {
                {0, "Inativo" },
                {1, "Ativo" }
            };
        }

        public static Dictionary<string, string> PopularComboTipoPessoa()
        {
            return new Dictionary<string, string>
            {
                {"f", "Pessoa Física"},
                {"j", "Pessoa Jurídica"}
            };
        }
    }
}
