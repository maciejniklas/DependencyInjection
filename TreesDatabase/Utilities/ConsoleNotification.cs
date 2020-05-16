using System;

namespace TreesDatabase.Utilities
{
    internal class ConsoleNotification : INotificationService
    {
        public void NotifyNameModified(string name)
        {
            Console.WriteLine($"Name was successfully modified to {name}");
        }
    }
}
