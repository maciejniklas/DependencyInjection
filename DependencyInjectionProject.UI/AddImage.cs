using EasyConsole;
using System;
using System.IO;

namespace DependencyInjectionProject.UI
{
    internal class AddImage : Page
    {
        public AddImage(Program program) : base("Add image", program) { }

        public override void Display()
        {
            Console.WriteLine("Enter image path");
            string path = Console.ReadLine();

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Directory not exists!");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("File not exists!");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            if(new FileInfo(path).Length / 1024 >= 5)
            {
                Console.WriteLine("File cannot be larger than 5kB");
                Console.WriteLine("Press any key to navigate home");
                Console.ReadKey();
                Program.NavigateHome();
            }

            string asciiArt = File.ReadAllText(path);

            Toolkit.DatabaseHandler.AddImage(Toolkit.SelectedTree.ID, asciiArt);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any key to navigate back");
            Console.ReadKey();
            Program.NavigateBack();
        }
    }
}