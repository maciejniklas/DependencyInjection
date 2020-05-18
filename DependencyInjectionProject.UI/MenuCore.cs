using DependencyInjectionProject.Database;
using DependencyInjectionProject.Utilities;
using EasyConsole;

namespace DependencyInjectionProject.UI
{
    public class MenuCore : Program
    {
        public MenuCore(DatabaseHandler databaseHandler, TreeService treeService) 
            : base("Dependency injection project", true)
        {
            Toolkit.DatabaseHandler = databaseHandler;
            Toolkit.TreeService = treeService;

            AddPage(new MainMenu(this));
            AddPage(new AllTrees(this));
            AddPage(new Exit(this));

            SetPage<MainMenu>();

            Run();
        }
    }
}
