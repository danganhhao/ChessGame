namespace ChessGame
{
    partial class Form1
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblClockBlack = new System.Windows.Forms.Label();
            this.lblClockWhite = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.choosePieceSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorfulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlBoard.Location = new System.Drawing.Point(41, 41);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(328, 297);
            this.pnlBoard.TabIndex = 0;
            // 
            // lblClockBlack
            // 
            this.lblClockBlack.AutoSize = true;
            this.lblClockBlack.BackColor = System.Drawing.SystemColors.Control;
            this.lblClockBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockBlack.Location = new System.Drawing.Point(415, 41);
            this.lblClockBlack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClockBlack.Name = "lblClockBlack";
            this.lblClockBlack.Size = new System.Drawing.Size(119, 46);
            this.lblClockBlack.TabIndex = 1;
            this.lblClockBlack.Text = "00:00";
            // 
            // lblClockWhite
            // 
            this.lblClockWhite.AutoSize = true;
            this.lblClockWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblClockWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockWhite.Location = new System.Drawing.Point(415, 272);
            this.lblClockWhite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClockWhite.Name = "lblClockWhite";
            this.lblClockWhite.Size = new System.Drawing.Size(119, 46);
            this.lblClockWhite.TabIndex = 2;
            this.lblClockWhite.Text = "00:00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choosePieceSkinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // choosePieceSkinToolStripMenuItem
            // 
            this.choosePieceSkinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.colorfulToolStripMenuItem,
            this.dToolStripMenuItem});
            this.choosePieceSkinToolStripMenuItem.Name = "choosePieceSkinToolStripMenuItem";
            this.choosePieceSkinToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.choosePieceSkinToolStripMenuItem.Text = "Choose Piece Skin";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // colorfulToolStripMenuItem
            // 
            this.colorfulToolStripMenuItem.Name = "colorfulToolStripMenuItem";
            this.colorfulToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorfulToolStripMenuItem.Text = "Colorful";
            this.colorfulToolStripMenuItem.Click += new System.EventHandler(this.colorfulToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dToolStripMenuItem.Text = "3D";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.dToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 388);
            this.Controls.Add(this.lblClockWhite);
            this.Controls.Add(this.lblClockBlack);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblClockBlack;
        private System.Windows.Forms.Label lblClockWhite;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem choosePieceSkinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorfulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
    }
}

