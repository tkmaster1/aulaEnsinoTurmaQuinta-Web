namespace TKMaster.AulaEnsino.Web.UI.Util
{
    public static class StringExtensions
    {
        public static string ToFormat(this string mensagem, params object[] parametros)
        {
            return string.Format(mensagem, parametros);
        }
    }
}
