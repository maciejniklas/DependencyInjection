using DependencyInjectionProject.Utilities;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace DependencyInjectionProject.Database
{
    public class SQLiteDatabaseModeler : IDatabaseModeler
    {
        private INotificationService notificationService;

        public SQLiteDatabaseModeler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void Build(string databaseName)
        {
            SQLiteConnection.CreateFile(databaseName);

            var connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = databaseName;

            var sqlBuilder = new StringBuilder();
            var connection = new SQLiteConnection(connectionStringBuilder.ConnectionString);
            var command = connection.CreateCommand();

            try
            {
                sqlBuilder.Append(@"CREATE TABLE IF NOT EXISTS Tree");
                sqlBuilder.Append(@"(");
                sqlBuilder.Append(@"id INTEGER PRIMARY KEY AUTOINCREMENT,");
                sqlBuilder.Append(@"name STRING NOT NULL,");
                sqlBuilder.Append(@"plantYear INTEGER NOT NULL,");
                sqlBuilder.Append(@"xCoord FLOAT NOT NULL,");
                sqlBuilder.Append(@"yCoord FLOAT NOT NULL");
                sqlBuilder.Append(@")");

                connection.Open();

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();

                sqlBuilder.Append(@"CREATE TABLE IF NOT EXISTS Image");
                sqlBuilder.Append(@"(");
                sqlBuilder.Append(@"id INTEGER PRIMARY KEY AUTOINCREMENT,");
                sqlBuilder.Append(@"treeID INTEGER,");
                sqlBuilder.Append(@"asciiArt STRING NOT NULL,");
                sqlBuilder.Append(@"FOREIGN KEY(treeID) REFERENCES Tree(id)");
                sqlBuilder.Append(@")");

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();

                sqlBuilder.Append(@"INSERT INTO Tree(name, plantYear, xCoord, yCoord) VALUES ('The First One', 2000, 54.223, 126.542)");

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();

                string image =
@"     ,\
    # (_
      _)\##
  ###/((_
       ))\####
     _((     
####/  )\
     ,;;'`;,
    (_______)
      \===/
      /===\
     /= aat =\";

                sqlBuilder.Append($"INSERT INTO Image(treeID, asciiArt) VALUES (1, '{image.Replace("'", "`").Replace('"', '`')}')");

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();
            }
            catch(Exception exception)
            {
                notificationService.HandleException(exception);
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
