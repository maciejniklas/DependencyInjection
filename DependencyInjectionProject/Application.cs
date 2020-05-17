using DependencyInjectionProject.Database;
using DependencyInjectionProject.Model;
using DependencyInjectionProject.Utilities;

namespace DependencyInjectionProject
{
    internal class Application : IApplication
    {
        private TreeService treeService;
        private DatabaseHandler databaseHandler;

        public Application(TreeService treeService, DatabaseHandler databaseHandler)
        {
            this.treeService = treeService;
            this.databaseHandler = databaseHandler;
        }

        public void Run()
        {
            Tree[] trees = databaseHandler.ReadTrees();

            treeService.Show(trees);

            trees[0].Name = "Modified Tree";

            databaseHandler.UpdateTree(trees[0]);
        }
    }
}
