using EasyConsole;

namespace DependencyInjectionProject.UI
{
    internal sealed class AllTrees : MenuPage
    {
        public AllTrees(Program program) : base("All trees", program) { }

        public override void Display()
        {
            Toolkit.TreeService.Show(Toolkit.DatabaseHandler.ReadAllTrees());

            base.Display();
        }
    }
}
