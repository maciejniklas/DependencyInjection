using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionProject.UI
{
    internal class AddTree : Page
    {
        public AddTree(Program program) : base("AddTree", program) { }

        public override void Display()
        {
            object raw;

            string name;
            Console.WriteLine("Name: ");
            name = Console.ReadLine();

            int plantYear;
            Console.WriteLine("Plant year: ");
            raw = Console.ReadLine();
            
            if(!int.TryParse(raw.ToString(), out plantYear))
            {
                Console.WriteLine($"{raw.ToString()} is not INTEGER");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            float xCoord;
            Console.WriteLine("X coordinate: ");
            raw = Console.ReadLine();
            
            if(!float.TryParse(raw.ToString(), out xCoord))
            {
                Console.WriteLine($"{raw.ToString()} is not FLOAT");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            float yCoord;
            Console.WriteLine("y coordinate: ");
            raw = Console.ReadLine();
            
            if(!float.TryParse(raw.ToString(), out yCoord))
            {
                Console.WriteLine($"{raw.ToString()} is not FLOAT");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            Toolkit.DatabaseHandler.AddTree(name, plantYear, xCoord, yCoord);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any key to navigate home");
            Console.ReadKey();
            Program.NavigateHome();
        }
    }
}
