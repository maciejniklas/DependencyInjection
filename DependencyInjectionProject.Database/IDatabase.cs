using System.Data;

namespace DependencyInjectionProject.Database
{
    public interface IDatabase
    {
        void NonQuery(string statement);
        DataTable Read(string statement);
    }
}
