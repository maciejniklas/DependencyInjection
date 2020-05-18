using ConsoleTables;
using DependencyInjectionProject.Utilities;

namespace DependencyInjectionProject.Model
{
    public class TreeService
    {
        private INotificationService notificationService;
        private ConsoleTable table;

        public TreeService(INotificationService notificationService)
        {
            this.notificationService = notificationService;
            
            table = new ConsoleTable("ID", "Name", "Plant year", "GPS coordinates");
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
            notificationService.NotifyGPSCoordsModified(gpsCoords.ToString());
        }

        public void Show(Tree tree)
        {
            table.Rows.Clear();
            table.AddRow(tree.ID, tree.Name, tree.PlantYear, tree.GPSCoordinates);
            table.Write();
        }

        public void Show(Tree[] trees)
        {
            table.Rows.Clear();

            if(trees != null)
            {
                foreach (var item in trees)
                {
                    table.AddRow(item.ID, item.Name, item.PlantYear, item.GPSCoordinates);
                }
            }            

            table.Write();
        }
    }
}
