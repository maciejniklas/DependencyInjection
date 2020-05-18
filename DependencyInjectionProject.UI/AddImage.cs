using EasyConsole;
using System;
using System.IO;

namespace DependencyInjectionProject.UI
{
    internal sealed class AddImage : Page
    {
        public AddImage(Program program) : base("Add image", program) { }

        public override void Display()
        {
            bool sentinel = true;
            Console.WriteLine("Enter image path");
            string path = Console.ReadLine();

            if(!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Directory not exists!");
                sentinel = false;
            }
            else if(!File.Exists(path))
            {
                Console.WriteLine("File not exists!");
                sentinel = false;
            }
            else if(File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                Console.WriteLine("This is a directory path");
                sentinel = false;
            }
            else if(new FileInfo(path).Length / 1024 >= 5)
            {
                Console.WriteLine("File cannot be larger than 5kB");
                sentinel = false;
            }

            if(!sentinel)
            {
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