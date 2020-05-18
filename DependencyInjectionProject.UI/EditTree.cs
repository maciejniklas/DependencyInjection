using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal class EditTree : Page
    {
        public EditTree(Program program) : base ("Edit tree", program) { }

        public override void Display()
        {
            Console.WriteLine("Enter values that you want to modify or leave empty");

            object raw;

            string name;
            Console.WriteLine("Name: ");
            name = Console.ReadLine();

            if(name != string.Empty)
            {
                Toolkit.TreeService.ModifyName(Toolkit.SelectedTree, name);
            }

            int plantYear;
            Console.WriteLine("Plant year: ");
            raw = Console.ReadLine();

            if (raw.ToString() != string.Empty)
            {
                if (!int.TryParse(raw.ToString(), out plantYear))
                {
                    Console.WriteLine($"{raw.ToString()} is not INTEGER");
                    Console.WriteLine("Press any key to navigate home");
                    Console.ReadKey();
                    Program.NavigateHome();
                }
                else
                {
                    Toolkit.TreeService.ModifyPlantYear(Toolkit.SelectedTree, plantYear);
                }
            }

            float xCoord = 0.0f;
            Console.WriteLine("X coordinate: ");
            raw = Console.ReadLine();

            if (raw.ToString() != string.Empty)
            {
                if (!float.TryParse(raw.ToString(), out xCoord))
                {
                    Console.WriteLine($"{raw.ToString()} is not FLOAT");
                    Console.WriteLine("Press any key to navigate home");
                    Console.ReadKey();
                    Program.NavigateHome();
                }
                else
                {
                    Toolkit.TreeService.ModifyGPSCoords(Toolkit.SelectedTree, new Model.Vector2(xCoord, Toolkit.SelectedTree.GPSCoordinates.Y));
                }
            }

            float yCoord = 0.0f;
            Console.WriteLine("Y coordinate: ");
            raw = Console.ReadLine();

            if (raw.ToString() != string.Empty)
            {
                if (!float.TryParse(raw.ToString(), out yCoord))
                {
                    Console.WriteLine($"{raw.ToString()} is not FLOAT");
                    Console.WriteLine("Press any key to navigate home");
                    Console.ReadKey();
                    Program.NavigateHome();
                }
                else
                {
                    Toolkit.TreeService.ModifyGPSCoords(Toolkit.SelectedTree, new Model.Vector2(Toolkit.SelectedTree.GPSCoordinates.X, yCoord));
                }
            }

            Toolkit.DatabaseHandler.UpdateTree(Toolkit.SelectedTree);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any key to navigate back");
            Console.ReadKey();
            Program.NavigateBack();
        }
    }
}
