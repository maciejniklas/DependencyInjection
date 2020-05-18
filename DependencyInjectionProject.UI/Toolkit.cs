using DependencyInjectionProject.Database;
using DependencyInjectionProject.Model;
using DependencyInjectionProject.Utilities;

namespace DependencyInjectionProject.UI
{
    internal static class Toolkit
    {
        public static TreeService TreeService { get; set; }
        public static ImageService ImageService { get; set; }
        public static DatabaseHandler DatabaseHandler { get; set; }
        public static Tree SelectedTree { get; set; }
    }
}
