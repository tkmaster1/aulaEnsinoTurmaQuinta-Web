namespace TKMaster.AulaEnsino.Web.UI.Application.BaseService
{
    public class Notification
    {
        #region Properties

        public string Key { get; }

        public string Message { get; }

        #endregion

        #region Constructor

        public Notification(string _key, string _message)
        {
            Key = _key;
            Message = _message;
        }

        #endregion
    }
}
