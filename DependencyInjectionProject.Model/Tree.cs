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
        
        public Tree(object[] data)
        {
            ID = int.Parse(data[0].ToString());
            Name = data[1].ToString();
            PlantYear = int.Parse(data[2].ToString());
            GPSCoordinates = new Vector2(float.Parse(data[3].ToString()), float.Parse(data[4].ToString()));
        }

        public override string ToString()
        {
            return $"{ID}\t{Name}\t{PlantYear}\t{GPSCoordinates}";
        }
    }
}
