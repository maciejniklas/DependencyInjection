using System;
using TreesDatabase.Models;

namespace TreesDatabase.Utilities
{
    internal class Application : IApplication
    {
        private TreeService treeService;

        public Application(TreeService treeService)
        {
            this.treeService = treeService;
        }

        public void Run()
        {
            Tree firstTree = new Tree("The First One");

            Console.WriteLine($"Current tree name is {firstTree.Name}");
            treeService.ModifyName(firstTree, "Modified Tree");
            Console.WriteLine($"Current tree name is {firstTree.Name}");
        }
    }
}
