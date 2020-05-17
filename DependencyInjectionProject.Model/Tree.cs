namespace DependencyInjectionProject.Model
{
    public class Tree
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public Tree(int id, string name)
        {
            ID = id;
            Name = name;
        }
        
        public Tree(string id, string name)
        {
            ID = int.Parse(id);
            Name = name;
        }

        public override string ToString()
        {
            return $"{ID}\t{Name}";
        }
    }
}
