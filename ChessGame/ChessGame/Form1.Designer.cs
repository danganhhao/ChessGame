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
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlBoard.Location = new System.Drawing.Point(22, 27);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(437, 366);
            this.pnlBoard.TabIndex = 0;
            // 
            // lblClockBlack
            // 
            this.lblClockBlack.AutoSize = true;
            this.lblClockBlack.BackColor = System.Drawing.SystemColors.Control;
            this.lblClockBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockBlack.Location = new System.Drawing.Point(553, 51);
            this.lblClockBlack.Name = "lblClockBlack";
            this.lblClockBlack.Size = new System.Drawing.Size(151, 58);
            this.lblClockBlack.TabIndex = 1;
            this.lblClockBlack.Text = "00:00";
            // 
            // lblClockWhite
            // 
            this.lblClockWhite.AutoSize = true;
            this.lblClockWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblClockWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockWhite.Location = new System.Drawing.Point(553, 335);
            this.lblClockWhite.Name = "lblClockWhite";
            this.lblClockWhite.Size = new System.Drawing.Size(151, 58);
            this.lblClockWhite.TabIndex = 2;
            this.lblClockWhite.Text = "00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 478);
            this.Controls.Add(this.lblClockWhite);
            this.Controls.Add(this.lblClockBlack);
            this.Controls.Add(this.pnlBoard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblClockBlack;
        private System.Windows.Forms.Label lblClockWhite;
    }
}

