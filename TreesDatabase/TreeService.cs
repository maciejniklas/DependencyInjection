using TreesDatabase.Models;
using TreesDatabase.Utilities;

namespace TreesDatabase
{
    internal class TreeService
    {
        private INotificationService notificationService;

        public TreeService(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void ModifyName(Tree tree, string name)
        {
            tree.Name = name;
            notificationService.NotifyNameModified(name);
        }
    }
}
