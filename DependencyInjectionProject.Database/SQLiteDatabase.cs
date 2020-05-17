using DependencyInjectionProject.Utilities;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DependencyInjectionProject.Database
{
    public class SQLiteDatabase : IDatabase
    {
        private INotificationService notificationService;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader reader;

        public SQLiteDatabase(IDatabaseModeler databaseModeler, INotificationService notificationService)
        {
            this.notificationService = notificationService;

            string databaseName = "database.db";

            if(!File.Exists(databaseName))
            {
                databaseModeler.Build(databaseName);
            }

            SQLiteConnectionStringBuilder connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = databaseName;

            connection = new SQLiteConnection();
            connection.ConnectionString = connectionStringBuilder.ToString();

            command = connection.CreateCommand();
        }

        public void NonQuery(string statement)
        {
            try
            {
                connection.Open();

                command.CommandText = statement;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                notificationService.HandleException(exception);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataTable Read(string statement)
        {
            DataTable result = new DataTable();

            try
            {
                connection.Open();

                command.CommandText = statement;
                command.CommandType = CommandType.Text;
                
                reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception exception)
            {
                notificationService.HandleException(exception);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }
    }
}
