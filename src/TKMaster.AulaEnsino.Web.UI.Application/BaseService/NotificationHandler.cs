using TKMaster.AulaEnsino.Web.UI.Application.BaseService.Interfaces;

namespace TKMaster.AulaEnsino.Web.UI.Application.BaseService
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        #region Properties

        private List<Notification> _listNotifications;
        public IReadOnlyCollection<Notification> Notifications => _listNotifications;
        public bool HasNotifications => _listNotifications.Any();

        #endregion

        #region Constructor

        public NotificationHandler()
        {
            _listNotifications = new List<Notification>();
        }

        #endregion

        #region Methods

        public Task Handle(Notification notification)
        {
            _listNotifications.Add(notification);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _listNotifications =new List<Notification>();
            GC.SuppressFinalize(this);
        }
        
        #endregion
    }
}
