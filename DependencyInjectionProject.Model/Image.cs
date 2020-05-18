namespace DependencyInjectionProject.Model
{
    public class Image
    {
        public int ID { get; set; }
        public int TreeID { get; set; }
        public string AsciiArt { get; set; }

        public Image(int id, int treeID, string asciiArt)
        {
            ID = id;
            TreeID = treeID;
            AsciiArt = asciiArt;
        }
        
        public Image(string id, string treeID, string asciiArt)
        {
            ID = int.Parse(id);
            TreeID = int.Parse(treeID);
            AsciiArt = asciiArt;
        }

        public override string ToString()
        {
            return $"ID: {ID}\nTree ID: {TreeID}\n{AsciiArt}";
        }
    }
}
