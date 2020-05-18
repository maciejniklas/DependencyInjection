using DependencyInjectionProject.Model;
using System;

namespace DependencyInjectionProject.Utilities
{
    public interface INotificationService
    {
        void HandleException(Exception exception);
        void NotifyGPSCoordsModified(Vector2 gpsCoords);
        void NotifyImageModified(string asciiArt);
        void NotifyNameModified(string name);
        void NotifyNotFound();
        void NotifyNotFound(Tree tree);
        void NotifyPlantYearModified(int plantYear);
    }
}
