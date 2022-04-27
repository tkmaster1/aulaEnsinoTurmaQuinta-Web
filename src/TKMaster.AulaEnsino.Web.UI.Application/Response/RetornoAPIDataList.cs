namespace TKMaster.AulaEnsino.Web.UI.Application.Response
{
    public class RetornoAPIDataList<T> : RetornoAPI
    {
        public List<T> Datas { get; set; }
    }
}
