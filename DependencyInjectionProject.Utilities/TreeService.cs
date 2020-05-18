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

        public void ModifyPlantYear(Tree tree, int plantYear)
        {
            tree.PlantYear = plantYear;
            notificationService.NotifyPlantYearModified(plantYear);
        }

        public void ModifyGPSCoords(Tree tree, Vector2 gpsCoords)
        {
            tree.GPSCoordinates = gpsCoords;
            notificationService.NotifyGPSCoordsModified(gpsCoords);
        }

        public void Show(Tree tree)
        {
            Console.WriteLine(tree);
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
