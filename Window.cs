using System;
using System.Drawing;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class Window : Form
    {    
        private const int UPPER_OFFSET = 60;
        private const int WIDTH_OFFSET = 16;

        private int m_FieldOffset;
        private readonly Game m_Game;
        private Bitmap m_GameField;
        private Graphics m_GameGraphics;

        public Window()
        {
            InitializeComponent();
            FillLevels();
            m_Game = new Game();
            var level = (Level) m_LevelCbx.SelectedItem;
            Size = new Size(level.Width * Game.CELL_SIZE + WIDTH_OFFSET, level.Height * Game.CELL_SIZE + UPPER_OFFSET);
        }

        private void FillLevels()
        {
            m_LevelCbx.Items.Add(new Level(9, 9, 10, "Newcomer: 9*9, 10 minutes"));
            m_LevelCbx.Items.Add(new Level(16, 16, 40, "Amateur: 16*16, 40 minutes"));
            m_LevelCbx.Items.Add(new Level(30, 16, 99, "Professional: 30*16, 99 minutes"));
            m_LevelCbx.SelectedIndex = 2;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (IsGameRunning())
            {
                var x = (e.X - m_FieldOffset) / Game.CELL_SIZE;
                var y = (e.Y - m_LevelCbx.Height) / Game.CELL_SIZE;
              
                if (e.Button == MouseButtons.Right)
                {
                    m_Game.CheckMine(x, y);
                }
                else
                {
                    if (!m_Timer.Enabled)
                    {
                        m_Timer.Start();
                    }
                    m_Game.OpenCell(x, y);
                }
                Invalidate();
                if (m_Game.GameOver)
                {
                    EndGame("Boom! It's a fail...");
                }
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            m_Game.UpdateTime();
            if (m_Game.GameOver)
            {
                Invalidate();
                EndGame("Time is over!");
            }
            UpdateTimeLabels();
        }

        private void EndGame(string message)
        {
            m_Timer.Stop();
            MessageBox.Show(message);
            m_LevelCbx.Enabled = m_StartBtn.Enabled = true;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (IsGameRunning())
            {
                m_GameGraphics.Clear(Color.White);
                m_Game.Draw(m_GameGraphics);
                e.Graphics.DrawImage(m_GameField, m_FieldOffset, m_LevelCbx.Height);
            }
        }

        private bool IsGameRunning()
        {
            return !m_StartBtn.Enabled;
        }

        private void UpdateTimeLabels()
        {
            m_MinutesLabel.Text = m_Game.Minutes.ToString();
            m_SecondsLabel.Text = m_Game.Seconds.ToString();
        }

        private void OnStartBtnClick(object sender, EventArgs e)
        {
            m_Game.Start((Level)m_LevelCbx.SelectedItem);
            m_GameField = new Bitmap(m_Game.Width * Game.CELL_SIZE, m_Game.Height * Game.CELL_SIZE);
            m_GameGraphics = Graphics.FromImage(m_GameField);
            Size = new Size(Size.Width, m_GameField.Height + UPPER_OFFSET);
            UpdateTimeLabels();
            m_StartBtn.Enabled = m_LevelCbx.Enabled = false;
            m_FieldOffset = (ClientSize.Width - m_GameField.Width)/2;
            Invalidate();
        }
    }    
}
