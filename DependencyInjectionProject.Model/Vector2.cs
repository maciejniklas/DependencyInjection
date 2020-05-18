namespace DependencyInjectionProject.Model
{
    public struct Vector2
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
