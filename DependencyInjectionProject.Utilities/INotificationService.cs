using System;

namespace DependencyInjectionProject.Utilities
{
    public interface INotificationService
    {
        void HandleException(Exception exception);
        void NotifyGPSCoordsModified(string gpsCoords);
        void NotifyImageModified(string asciiArt);
        void NotifyNameModified(string name);
        void NotifyNotFound();
        void NotifyPlantYearModified(int plantYear);
    }
}
