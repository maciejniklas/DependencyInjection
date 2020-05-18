using DependencyInjectionProject.Database;
using DependencyInjectionProject.Utilities;

namespace DependencyInjectionProject.UI
{
    internal static class Toolkit
    {
        public static TreeService TreeService { get; set; }
        public static DatabaseHandler DatabaseHandler { get; set; }
    }
}
