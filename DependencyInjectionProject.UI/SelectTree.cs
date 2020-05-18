using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal class SelectTree : Page
    {
        public SelectTree(Program program) : base("Select tree", program)
        { }

        public override void Display()
        {
            Console.WriteLine("Enter ID of tree that should be selected: ");
            object raw = Console.ReadLine();
            int id;

            if(!int.TryParse(raw.ToString(), out id))
            {
                Console.WriteLine($"{raw.ToString()} is not INTEGER value");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            Toolkit.SelectedTree = Toolkit.DatabaseHandler.ReadTree(id);

            if(Toolkit.SelectedTree == null)
            {
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            Program.NavigateTo<TreeOptions>();
        }
    }
}
