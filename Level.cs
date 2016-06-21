namespace minesweeper
{
    public class Level
    {
        public int Width { get; }
        public int Height { get; }
        public int TimeLimit { get; }
        public string Description { get; }

        public Level(int w, int h, int limit, string description)
        {
            Width = w;
            Height = h;
            TimeLimit = limit;
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
