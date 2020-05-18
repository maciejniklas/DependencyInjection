using DependencyInjectionProject.Database;
using DependencyInjectionProject.Utilities;
using EasyConsole;

namespace DependencyInjectionProject.UI
{
    public class MenuCore : Program
    {
        public MenuCore(DatabaseHandler databaseHandler, TreeService treeService, ImageService imageService) : base("Dependency injection project", true)
        {
            Toolkit.DatabaseHandler = databaseHandler;
            Toolkit.TreeService = treeService;
            Toolkit.ImageService = imageService;

            AddPage(new MainMenu(this));
            AddPage(new AllTrees(this));
            AddPage(new AddTree(this));
            AddPage(new SelectTree(this));
            AddPage(new Exit(this));

            AddPage(new TreeOptions(this));
            AddPage(new EditTree(this));
            AddPage(new DeleteTree(this));

            AddPage(new ImageOptions(this));
            AddPage(new AddImage(this));
            AddPage(new DeleteImage(this));

            SetPage<MainMenu>();

            Run();
        }
    }
}
