using DependencyInjectionProject.Model;
using System;

namespace DependencyInjectionProject.Utilities
{
    public interface INotificationService
    {
        void HandleException(Exception exception);
        void NotifyNameModified(string name);
        void NotifyNotFound(Tree tree);
    }
}
