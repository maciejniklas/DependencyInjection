using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal sealed class DeleteImage : Page
    {
        public DeleteImage(Program program) : base("Delete image", program) { }

        public override void Display()
        {
            int id = Toolkit.UserInput<int>("Image id", Mode.Add, () => Program.NavigateBack());

            Console.WriteLine("Are you sure? (Y/N)");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "Y":
                case "y":
                    if(Toolkit.DatabaseHandler.DeleteImage(Toolkit.SelectedTree, id))
                    {
                        Console.WriteLine("Success!");
                        Console.WriteLine("Press any key to navigate back");
                        Console.ReadLine();
                        Program.NavigateBack();
                    }
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
