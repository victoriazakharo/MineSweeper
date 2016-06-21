using System;
using System.Collections.Generic;
using System.Drawing;
using minesweeper.Properties;

namespace minesweeper
{
    public class Game
    {
        public const int CELL_SIZE = 20;

        public int Width => m_Level.Width;
        public int Height => m_Level.Height;
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public bool GameOver { get; private set; }

        private Level m_Level;
        private Cell[,] m_Grid;
        private Bitmap m_Empty;
        private Bitmap m_Mine;
        private Bitmap m_Flag;
        private readonly List<Bitmap> m_NumberBitmaps;

        public Game()
        {
            m_NumberBitmaps = new List<Bitmap>();
            InitializeImages();
        }

        public void Start(Level level)
        {
            m_Level = level;
            GameOver = false;
            m_Grid = new Cell[Width, Height];
            Minutes = 0;
            Seconds = 0;
            InitializeField();
        }

        public void Draw(Graphics g)
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    var cell = m_Grid[x, y];
                    var image = GameOver && cell.IsMine ? m_Mine : cell.MarkedAsMine ? m_Flag : cell.Seen ? m_NumberBitmaps[cell.Number] : m_Empty;
                    g.DrawImage(image, new Point(x*CELL_SIZE, y*CELL_SIZE));
                }
            }
        }

        public void CheckMine(int x, int y)
        {
             m_Grid[x, y].MarkedAsMine = !m_Grid[x, y].MarkedAsMine;
        }

        public void OpenCell(int x, int y)
        {
            if (m_Grid[x, y].IsMine)
            {
                GameOver = true;
            }
            else
            {
                Open(x, y);
            }
        }

        public void UpdateTime()
        {
            if (Seconds != 60)
            {
                Seconds++;
            }
            else
            {
                Minutes++;
                Seconds = 0;
            }
            if (Minutes == m_Level.TimeLimit)
            {
                GameOver = true;
            }
        }

        private void InitializeField()
        {
            var permutation = new Cell[Width * Height];
            var i = 0;
            for (var k = 0; k < Width; k++)
            {
                for (var l = 0; l < Height; l++)
                {
                    permutation[i++] = m_Grid[k, l] = new Cell(k, l);
                }
            }
            var rnd = new Random();
            var mines = m_Level.TimeLimit;
            for (i = 0; i < mines; ++i)
            {
                SwapCells(ref permutation[i], ref permutation[i + rnd.Next() % (Width * Height - i)]);
            }
            for (i = 0; i < mines; i++)
            {
                permutation[i].IsMine = true;
            }
            CountMineNumbers();
        }

        private void Open(int x, int y)
        {
            m_Grid[x, y].Seen = true;
            if (m_Grid[x, y].Number == 0)
            {
                ForCellsAround(x, y, (i, j) => 
                {
                    var cell = m_Grid[i, j];
                    if (!cell.Seen && !cell.IsMine)
                    {
                        cell.Seen = true;
                        if (cell.Number == 0)
                        {
                            Open(i, j);
                        }
                    }
                });
            }            
        }       

        private void CountMineNumbers()
        {
            foreach (var cell in m_Grid)
            {
                var i = 0;
                if (!cell.IsMine)
                {
                    ForCellsAround(cell.X, cell.Y, (x,y) => { if(m_Grid[x, y].IsMine) i++; });                    
                }
                cell.Number = i;
            }
        }

        private void ForCellsAround(int x, int y, Action<int, int> action)
        {
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var posI = x + i;
                    var posJ = y + j;
                    if (posI >= 0 && posI < Width && posJ >= 0 && posJ < Height)
                    {
                        action(posI, posJ);
                    }
                }
            }
        }

        private static void SwapCells(ref Cell a, ref Cell b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private void InitializeImages()
        {
            for (var i = 0; i < 9; i++)
            {
                var bitmap = (Bitmap)Resources.ResourceManager.GetObject($"_{i}");
                bitmap.SetResolution(96, 96);
                m_NumberBitmaps.Add(bitmap);
            }
            m_Empty = (Bitmap)Resources.ResourceManager.GetObject("empty");
            m_Empty.SetResolution(96, 96);
            m_Mine = (Bitmap)Resources.ResourceManager.GetObject("mine");
            m_Mine.SetResolution(96, 96);
            m_Flag = (Bitmap)Resources.ResourceManager.GetObject("flag");
            m_Flag.SetResolution(96, 96);
        }
    }
}
