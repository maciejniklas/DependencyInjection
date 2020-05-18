using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal sealed class AddTree : Page
    {
        public AddTree(Program program) : base("AddTree", program) { }

        public override void Display()
        {
            string name = Toolkit.UserInput<string>("Name", Mode.Add, Program.NavigateHome);
            int plantYear = Toolkit.UserInput<int>("Plant year", Mode.Add, Program.NavigateHome);
            float xCoord = Toolkit.UserInput<float>("X coordinate", Mode.Add, Program.NavigateHome);
            float yCoord = Toolkit.UserInput<float>("Y coordinate", Mode.Add, Program.NavigateHome);

            Toolkit.DatabaseHandler.AddTree(name, plantYear, xCoord, yCoord);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any key to navigate home");
            Console.ReadKey();
            Program.NavigateHome();
        }
    }
}
