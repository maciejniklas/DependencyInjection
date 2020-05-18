using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal class DeleteTree : Page
    {
        public DeleteTree(Program program) : base("Delete tree", program) { }

        public override void Display()
        {
            Console.WriteLine("Are you sure? (Y/N)");
            string answer = Console.ReadLine();

            switch(answer)
            {
                case "Y":
                case "y":
                    Toolkit.DatabaseHandler.DeleteTree(Toolkit.SelectedTree);
                    Console.WriteLine("Success!");
                    Console.WriteLine("Press any key to navigate home");
                    Console.ReadLine();
                    Program.NavigateHome();
                    break;
                case "N":
                case "n":
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }

            Console.WriteLine("Press any key to navigate back");
            Console.ReadLine();

            Program.NavigateBack();
        }
    }
}
