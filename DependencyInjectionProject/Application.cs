using DependencyInjectionProject.Database;
using DependencyInjectionProject.Model;
using DependencyInjectionProject.Utilities;

namespace DependencyInjectionProject
{
    internal class Application : IApplication
    {
        private TreeService treeService;
        private DatabaseHandler databaseHandler;
        private ImageService imageService;

        public Application(TreeService treeService, DatabaseHandler databaseHandler, ImageService imageService)
        {
            this.treeService = treeService;
            this.databaseHandler = databaseHandler;
            this.imageService = imageService;
        }

        public void Run()
        {
            Tree[] trees = databaseHandler.ReadTrees();
            treeService.Show(trees);

            treeService.ModifyName(trees[0], "Modified Tree");
            databaseHandler.UpdateTree(trees[0]);

            treeService.Show(trees[0]);

            Image[] images = databaseHandler.ReadImages();
            imageService.Show(images);
        }
    }
}
