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

        public void NotifyGPSCoordsModified(Vector2 gpsCoords)
        {
            Console.WriteLine($"GPS coordinates was successfully modified to {gpsCoords}");
        }

        public void NotifyImageModified(string asciiArt)
        {
            Console.WriteLine("Image was successfully modified");
            Console.WriteLine(asciiArt);
        }

        public void NotifyNameModified(string name)
        {
            Console.WriteLine($"Name was successfully modified to {name}");
        }

        public void NotifyNotFound()
        {
            Console.WriteLine("Any object found");
        }

        public void NotifyNotFound(Tree tree)
        {
            Console.WriteLine($"Not found tree with given id {tree.ID}");
        }

        public void NotifyPlantYearModified(int plantYear)
        {
            Console.WriteLine($"Plant year was successfully modified to {plantYear}");
        }
    }
}
