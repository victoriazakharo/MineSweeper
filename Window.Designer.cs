namespace minesweeper
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_MinutesLabel = new System.Windows.Forms.Label();
            this.m_Timer = new System.Windows.Forms.Timer(this.components);
            this.m_SeparatorLabel = new System.Windows.Forms.Label();
            this.m_SecondsLabel = new System.Windows.Forms.Label();
            this.m_StartBtn = new System.Windows.Forms.Button();
            this.m_LevelCbx = new System.Windows.Forms.ComboBox();
            this.m_Panel = new System.Windows.Forms.Panel();
            this.m_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_MinutesLabel
            // 
            this.m_MinutesLabel.AutoSize = true;
            this.m_MinutesLabel.Location = new System.Drawing.Point(13, 7);
            this.m_MinutesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_MinutesLabel.Name = "m_MinutesLabel";
            this.m_MinutesLabel.Size = new System.Drawing.Size(18, 20);
            this.m_MinutesLabel.TabIndex = 0;
            this.m_MinutesLabel.Text = "0";
            // 
            // m_Timer
            // 
            this.m_Timer.Interval = 1000;
            this.m_Timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // m_SeparatorLabel
            // 
            this.m_SeparatorLabel.AutoSize = true;
            this.m_SeparatorLabel.Location = new System.Drawing.Point(35, 5);
            this.m_SeparatorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_SeparatorLabel.Name = "m_SeparatorLabel";
            this.m_SeparatorLabel.Size = new System.Drawing.Size(13, 20);
            this.m_SeparatorLabel.TabIndex = 1;
            this.m_SeparatorLabel.Text = ":";
            // 
            // m_SecondsLabel
            // 
            this.m_SecondsLabel.AutoSize = true;
            this.m_SecondsLabel.Location = new System.Drawing.Point(53, 7);
            this.m_SecondsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_SecondsLabel.Name = "m_SecondsLabel";
            this.m_SecondsLabel.Size = new System.Drawing.Size(18, 20);
            this.m_SecondsLabel.TabIndex = 2;
            this.m_SecondsLabel.Text = "0";
            // 
            // m_StartBtn
            // 
            this.m_StartBtn.Location = new System.Drawing.Point(0, 0);
            this.m_StartBtn.Margin = new System.Windows.Forms.Padding(0);
            this.m_StartBtn.Name = "m_StartBtn";
            this.m_StartBtn.Size = new System.Drawing.Size(78, 34);
            this.m_StartBtn.TabIndex = 3;
            this.m_StartBtn.Text = "Start";
            this.m_StartBtn.UseVisualStyleBackColor = true;
            this.m_StartBtn.Click += new System.EventHandler(this.OnStartBtnClick);
            // 
            // m_LevelCbx
            // 
            this.m_LevelCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_LevelCbx.FormattingEnabled = true;
            this.m_LevelCbx.Location = new System.Drawing.Point(78, 0);
            this.m_LevelCbx.Margin = new System.Windows.Forms.Padding(0);
            this.m_LevelCbx.Name = "m_LevelCbx";
            this.m_LevelCbx.Size = new System.Drawing.Size(306, 28);
            this.m_LevelCbx.TabIndex = 4;
            // 
            // m_Panel
            // 
            this.m_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Panel.Controls.Add(this.m_SecondsLabel);
            this.m_Panel.Controls.Add(this.m_MinutesLabel);
            this.m_Panel.Controls.Add(this.m_SeparatorLabel);
            this.m_Panel.Location = new System.Drawing.Point(445, 0);
            this.m_Panel.Name = "m_Panel";
            this.m_Panel.Size = new System.Drawing.Size(82, 28);
            this.m_Panel.TabIndex = 5;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 372);
            this.Controls.Add(this.m_Panel);
            this.Controls.Add(this.m_LevelCbx);
            this.Controls.Add(this.m_StartBtn);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Window";
            this.Text = "MineSweeper";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            this.m_Panel.ResumeLayout(false);
            this.m_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label m_MinutesLabel;
        private System.Windows.Forms.Timer m_Timer;
        private System.Windows.Forms.Label m_SeparatorLabel;
        private System.Windows.Forms.Label m_SecondsLabel;
        private System.Windows.Forms.Button m_StartBtn;
        public System.Windows.Forms.ComboBox m_LevelCbx;
        private System.Windows.Forms.Panel m_Panel;
    }
}

