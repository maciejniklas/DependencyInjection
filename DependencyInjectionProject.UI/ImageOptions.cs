using EasyConsole;

namespace DependencyInjectionProject.UI
{
    internal class ImageOptions : MenuPage
    {
        public ImageOptions(Program program) : base("Image options", program) 
        {
            Menu.Add(new Option("Add image", () => program.NavigateTo<AddImage>()));
            Menu.Add(new Option("Delete image", () => program.NavigateTo<DeleteImage>()));
        }

        public override void Display()
        {
            Toolkit.ImageService.Show(Toolkit.DatabaseHandler.ReadImages(Toolkit.SelectedTree.ID));

            base.Display();
        }
    }
}
