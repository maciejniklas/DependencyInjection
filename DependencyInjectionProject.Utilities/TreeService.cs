using DependencyInjectionProject.Model;
using System;

namespace DependencyInjectionProject.Utilities
{
    public class TreeService
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

        public void Show(Tree[] trees)
        {
            foreach(var item in trees)
            {
                Console.WriteLine(item);
            }
        }
    }
}
