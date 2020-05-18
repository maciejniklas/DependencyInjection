using DependencyInjectionProject.Model;
using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal sealed class ModifyTree : Page
    {
        public ModifyTree(Program program) : base ("Edit tree", program) { }

        public override void Display()
        {
            Console.WriteLine("Enter values that you want to modify or leave empty");

            string name = Toolkit.UserInput<string>("Name", Mode.Modify, null);
            if(!string.IsNullOrWhiteSpace(name))
            {
                Toolkit.TreeService.ModifyName(Toolkit.SelectedTree, name);
            }

            int plantYear = Toolkit.UserInput<int>("Plant year", Mode.Modify, null);
            if(plantYear != 0)
            {
                Toolkit.TreeService.ModifyPlantYear(Toolkit.SelectedTree, plantYear);
            }

            float xCoord = Toolkit.UserInput<float>("X coordinate", Mode.Modify, null);
            if(Math.Abs(xCoord) >= float.Epsilon)
            {
                Toolkit.TreeService.ModifyGPSCoords(Toolkit.SelectedTree, new Vector2(xCoord, Toolkit.SelectedTree.GPSCoordinates.Y));
            }

            float yCoord = Toolkit.UserInput<float>("Y coordinate", Mode.Modify, null);
            if(Math.Abs(yCoord) >= float.Epsilon)
            {
                Toolkit.TreeService.ModifyGPSCoords(Toolkit.SelectedTree, new Model.Vector2(Toolkit.SelectedTree.GPSCoordinates.X, yCoord));
            }

            Toolkit.DatabaseHandler.UpdateTree(Toolkit.SelectedTree);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any key to navigate back");
            Console.ReadKey();
            Program.NavigateBack();
        }
    }
}
