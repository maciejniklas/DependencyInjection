using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal sealed class SelectTree : Page
    {
        public SelectTree(Program program) : base("Select tree", program)
        { }

        public override void Display()
        {
            int id = Toolkit.UserInput<int>("Enter ID of tree that should be selected", Mode.Add, Program.NavigateHome);

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
