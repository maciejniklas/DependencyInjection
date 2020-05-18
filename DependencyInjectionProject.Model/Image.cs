namespace DependencyInjectionProject.Model
{
    public class Image
    {
        public int ID { get; private set; }
        public int TreeID { get; internal set; }
        public string AsciiArt { get; internal set; }

        public Image(int id, int treeID, string asciiArt)
        {
            ID = id;
            TreeID = treeID;
            AsciiArt = asciiArt;
        }
        
        public Image(object[] data)
        {
            ID = int.Parse(data[0].ToString()); ;
            TreeID = int.Parse(data[1].ToString());
            AsciiArt = data[2].ToString();
        }

        public override string ToString()
        {
            return $"ID: {ID}\nTree ID: {TreeID}\n{AsciiArt}";
        }
    }
}
