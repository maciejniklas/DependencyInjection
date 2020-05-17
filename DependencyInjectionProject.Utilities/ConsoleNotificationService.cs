using DependencyInjectionProject.Model;
using System;

namespace DependencyInjectionProject.Utilities
{
    public class ConsoleNotificationService : INotificationService
    {
        public void HandleException(Exception exception)
        {
            Console.WriteLine("EXCEPTION OCCURED!");
            Console.WriteLine("Message");
            Console.WriteLine(exception.Message);
            Console.WriteLine("Trace");
            Console.WriteLine(exception.StackTrace);
        }

        public void NotifyNameModified(string name)
        {
            Console.WriteLine($"Name was successfully modified to {name}");
        }

        public void NotifyNotFound(Tree tree)
        {
            Console.WriteLine("Not found that tree in database");
            Console.WriteLine(tree);
        }
    }
}
