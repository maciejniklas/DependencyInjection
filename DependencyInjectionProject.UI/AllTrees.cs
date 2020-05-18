using EasyConsole;

namespace DependencyInjectionProject.UI
{
    internal class AllTrees : MenuPage
    {
        public AllTrees(Program program)
            : base("All trees", program)
        { }

        public override void Display()
        {
            Toolkit.TreeService.Show(Toolkit.DatabaseHandler.ReadTrees());

            base.Display();
        }
    }
}
