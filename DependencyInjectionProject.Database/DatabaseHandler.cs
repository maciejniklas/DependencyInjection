using DependencyInjectionProject.Model;
using DependencyInjectionProject.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public bool AddImage(int treeID, string asciiArt)
        {
            database.NonQuery($"INSERT INTO Image(treeID, asciiArt) VALUES ({treeID}, '{asciiArt.Replace("'", "`").Replace('"', '`')}')");
            return true;
        }

        public bool AddTree(string name, int plantYear, float xCoord, float yCoord)
        {
            database.NonQuery($"INSERT INTO Tree(name, plantYear, xCoord, yCoord) VALUES ('{name}', {plantYear}, {xCoord.ToString().Replace(',', '.')}, {yCoord.ToString().Replace(',', '.')})");
            return true;
        }

        public bool DeleteImage(Tree tree, int id)
        {
            if(ReadImages(tree.ID) == null)
            {
                notificationService.NotifyNotFound();
                return false;
            }
            else if(ReadImages(tree.ID).Where(item => item.ID == id).Count() == 0)
            {
                notificationService.NotifyNotFound();
                return false;
            }

            database.NonQuery($"DELETE FROM Image WHERE id = {id}");
            return true;
        }

        public bool DeleteTree(Tree tree)
        {
            if (ReadTree(tree.ID) == null)
            {
                notificationService.NotifyNotFound();
                return false;
            }

            database.NonQuery($"DELETE FROM Tree WHERE id = {tree.ID}");
            return true;
        }

        public Image[] ReadImages(int treeID)
        {
            DataTable data = database.Read($"SELECT * FROM Image WHERE treeID = {treeID}");

            if (data.Rows.Count == 0)
            {
                notificationService.NotifyNotFound();
                return null;
            }

            List<Image> result = new List<Image>();

            foreach(DataRow row in data.Rows)
            {
                result.Add(new Image(row.ItemArray));
            }

            return result.ToArray();
        }

        public Tree[] ReadAllTrees()
        {
            DataTable data = database.Read(@"SELECT * FROM Tree");

            if (data.Rows.Count == 0)
            {
                notificationService.NotifyNotFound();
                return null;
            }

            List<Tree> result = new List<Tree>();

            foreach(DataRow row in data.Rows)
            {
                result.Add(new Tree(row.ItemArray));
            }

            return result.ToArray();
        }

        public Tree ReadTree(int id)
        {
            DataTable data = database.Read($"SELECT * FROM Tree WHERE id = {id}");

            if (data.Rows.Count == 0)
            {
                notificationService.NotifyNotFound();
                return null;
            }

            return new Tree(data.Rows[0].ItemArray);
        }

        public void UpdateTree(Tree tree)
        {
            if(ReadTree(tree.ID) == null)
            {
                notificationService.NotifyNotFound();
                return;
            }

            database.NonQuery($"UPDATE Tree SET name = '{tree.Name}', plantYear = {tree.PlantYear}, xCoord = {tree.GPSCoordinates.X.ToString().Replace(',', '.')}, yCoord = {tree.GPSCoordinates.Y.ToString().Replace(',', '.')} WHERE id = {tree.ID}");
        }
    }
}
