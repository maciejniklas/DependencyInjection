using DependencyInjectionProject.Model;
using DependencyInjectionProject.Utilities;
using System;
using System.Collections.Generic;
using System.Data;

namespace DependencyInjectionProject.Database
{
    public class DatabaseHandler
    {
        private IDatabase database;
        private INotificationService notificationService;

        public DatabaseHandler(IDatabase database, INotificationService notificationService)
        {
            this.database = database;
            this.notificationService = notificationService;
        }

        public Tree[] ReadTrees()
        {
            DataTable data = database.Read(@"SELECT * FROM Tree");
            List<Tree> result = new List<Tree>();

            foreach(DataRow row in data.Rows)
            {
                result.Add(new Tree(row.ItemArray[0].ToString(), row.ItemArray[1].ToString()));
            }

            return result.ToArray();
        }

        public void UpdateTree(Tree tree)
        {
            DataTable data = database.Read($"SELECT * FROM Tree WHERE ID = {tree.ID}");

            if(data.Rows.Count == 0)
            {
                notificationService.NotifyNotFound(tree);
                return;
            }

            database.NonQuery($"UPDATE Tree SET name = '{tree.Name}' WHERE id = {tree.ID}");
        }
    }
}
