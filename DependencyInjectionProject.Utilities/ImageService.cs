using DependencyInjectionProject.Model;
using System;

namespace DependencyInjectionProject.Utilities
{
    public class ImageService
    {
        private INotificationService notificationService;

        public ImageService(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void ModifyImage(Image image, string asciiArt)
        {
            image.AsciiArt = asciiArt;
            notificationService.NotifyImageModified(asciiArt);
        }

        public void Show(Image image)
        {
            Console.WriteLine(image);
        }

        public void Show(Image[] images)
        {
            foreach(var item in images)
            {
                Console.WriteLine(item);
            }
        }
    }
}
