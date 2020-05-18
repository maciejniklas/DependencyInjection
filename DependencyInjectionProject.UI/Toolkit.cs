using DependencyInjectionProject.Database;
using DependencyInjectionProject.Model;
using System;
using System.ComponentModel;
using System.Linq;

namespace DependencyInjectionProject.UI
{
    internal static class Toolkit
    {
        public static DatabaseHandler DatabaseHandler { get; set; }
        public static ImageService ImageService { get; set; }
        public static Tree SelectedTree { get; set; }
        public static TreeService TreeService { get; set; }

        private static bool TryParse(string input, Type targetType)
        {
            try
            {
                TypeDescriptor.GetConverter(targetType).ConvertFromString(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T UserInput<T>(string label, Mode mode, Action action)
        {
            Console.WriteLine($"{label}: ");
            object raw = Console.ReadLine();

            switch(mode)
            {
                case Mode.Modify:
                    if (raw.ToString() == string.Empty)
                    {
                        return default;
                    }
                    break;
                case Mode.Add:
                    if (!TryParse(raw.ToString(), typeof(T)))
                    {
                        Console.WriteLine($"{raw} is not {typeof(T).ToString().Split('.').Last()}");
                        Console.WriteLine($"Press any key to navigate {mode.ToString().Split('.').Last()}");
                        Console.ReadKey();
                        action.Invoke();
                        return default;
                    }
                    break;
            }

            return (T)Convert.ChangeType(raw.ToString(), typeof(T));
        }
    }
}
