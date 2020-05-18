namespace DependencyInjectionProject.Model
{
    public class Tree
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PlantYear { get; set; }
        public Vector2 GPSCoordinates { get; set; }
        
        public Tree(int id, string name, int plantYear, Vector2 gpsCoordinates)
        {
            ID = id;
            Name = name;
            PlantYear = plantYear;
            GPSCoordinates = gpsCoordinates;
        }
        
        public Tree(string id, string name, string plantYear, string x, string y)
        {
            ID = int.Parse(id);
            Name = name;
            PlantYear = int.Parse(plantYear);
            GPSCoordinates = new Vector2(float.Parse(x), float.Parse(y));
        }

        public override string ToString()
        {
            return $"{ID}\t{Name}\t{PlantYear}\t{GPSCoordinates}";
        }
    }
}
