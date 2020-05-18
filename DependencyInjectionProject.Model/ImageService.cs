using System;

namespace DependencyInjectionProject.Model
{
    public class ImageService
    {
        public void Show(Image image)
        {
            Console.WriteLine(image);
        }

        public void Show(Image[] images)
        {
            if(images != null)
            {
                foreach (var item in images)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
