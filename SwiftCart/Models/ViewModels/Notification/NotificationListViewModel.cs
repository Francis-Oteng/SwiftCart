using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels
{
    public class NotificationListViewModel
    {
        public IEnumerable<Notification> Notifications { get; set; }
            = new List<Notification>();
    }
}

