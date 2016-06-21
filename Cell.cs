namespace minesweeper
{
    public class Cell
    {       
        public bool MarkedAsMine { get; set; }
        public bool IsMine { get; set; }
        public int Number { get; set; }
        public bool Seen { get; set; }
        public int X { get; }
        public int Y { get; }

        public Cell(int a, int b)
        {
            X = a;
            Y = b;
        }
    }
}
