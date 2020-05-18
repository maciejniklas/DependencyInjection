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
                sqlBuilder.Append(@"FOREIGN KEY(treeID) REFERENCES Tree(id) ON DELETE CASCADE");
                sqlBuilder.Append(@")");

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();

                sqlBuilder.Append(@"INSERT INTO Tree(name, plantYear, xCoord, yCoord) VALUES ('The First One', 2000, 54.223, 126.542), ('American Hornbeam', 1950, 123.6754321, 120.54326542), ('Pitch Pine', 1800, 110.341367345, 73.143655472435)");

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

                image =
@"              v .   ._, |_  .,
           `-._\/  .  \ /    |/_
               \\  _\, y | \//
         _\_.___\\, \\/ -.\||
           `7-,--.`._||  / / ,
           /'     `-. `./ / |/_.'
                     |    |//
                     |_    /
                     |-   |
                     |   =|
                     |    |
--------------------/ ,  . \--------._";

                sqlBuilder.Append($"INSERT INTO Image(treeID, asciiArt) VALUES (1, '{image.Replace("'", "`").Replace('"', '`')}')");

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();

                image =
@"       _-_
    /~~   ~~\
 /~~         ~~\
{               }
 \  _-     -_  /
   ~  \\ //  ~
_- -   | | _- _
  _ -  | |   -_
      // \\";

                sqlBuilder.Append($"INSERT INTO Image(treeID, asciiArt) VALUES (2, '{image.Replace("'", "`").Replace('"', '`')}')");

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
