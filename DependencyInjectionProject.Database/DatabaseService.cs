using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionProject.Database
{
    class DatabaseService
    {
        private IDatabase database;

        public DatabaseService(IDatabase database)
        {
            this.database = database;
        }
    }
}
