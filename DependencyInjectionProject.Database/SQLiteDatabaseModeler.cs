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
                sqlBuilder.Append(@"name STRING NOT NULL");
                sqlBuilder.Append(@")");

                connection.Open();

                command.CommandText = sqlBuilder.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                sqlBuilder.Clear();

                sqlBuilder.Append(@"INSERT INTO Tree(Name) VALUES ('The First One')");

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
