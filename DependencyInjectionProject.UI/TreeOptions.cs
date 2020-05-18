using DependencyInjectionProject.Model;
using EasyConsole;

namespace DependencyInjectionProject.UI
{
    internal class TreeOptions : MenuPage
    {
        public TreeOptions(Program program) : base("Tree options", program)
        {
            Menu.Add(new Option("Images", () => program.NavigateTo<ImageOptions>()));
            Menu.Add(new Option("Edit tree", () => program.NavigateTo<EditTree>()));
            Menu.Add(new Option("Delete tree", () => program.NavigateTo<DeleteTree>()));
            Menu.Add(new Option("Home", () => program.NavigateHome()));
        }

        public override void Display()
        {
            Toolkit.TreeService.Show(Toolkit.SelectedTree);

            base.Display();
        }
    }
}
