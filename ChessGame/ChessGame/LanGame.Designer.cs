namespace ChessGame
{
    partial class LanGame
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSanSang = new System.Windows.Forms.Button();
            this.lblloi = new System.Windows.Forms.Label();
            this.btnChat = new System.Windows.Forms.Button();
            this.txtchat = new System.Windows.Forms.TextBox();
            this.lstChatBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHost = new System.Windows.Forms.Panel();
            this.pnlGuest = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(768, 497);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 35);
            this.btnExit.TabIndex = 48;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.Red;
            this.btnPlay.Location = new System.Drawing.Point(832, 20);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(89, 35);
            this.btnPlay.TabIndex = 44;
            this.btnPlay.Text = "Bắt Đầu";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnSanSang
            // 
            this.btnSanSang.Enabled = false;
            this.btnSanSang.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanSang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSanSang.Location = new System.Drawing.Point(684, 20);
            this.btnSanSang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSanSang.Name = "btnSanSang";
            this.btnSanSang.Size = new System.Drawing.Size(92, 35);
            this.btnSanSang.TabIndex = 42;
            this.btnSanSang.Text = "Sẵn Sàng";
            this.btnSanSang.UseVisualStyleBackColor = true;
            // 
            // lblloi
            // 
            this.lblloi.Location = new System.Drawing.Point(7, 7);
            this.lblloi.Name = "lblloi";
            this.lblloi.Size = new System.Drawing.Size(100, 23);
            this.lblloi.TabIndex = 47;
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(883, 453);
            this.btnChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(58, 24);
            this.btnChat.TabIndex = 41;
            this.btnChat.Text = "Gửi  Tin";
            this.btnChat.UseVisualStyleBackColor = true;
            // 
            // txtchat
            // 
            this.txtchat.Location = new System.Drawing.Point(661, 453);
            this.txtchat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtchat.Name = "txtchat";
            this.txtchat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtchat.Size = new System.Drawing.Size(209, 22);
            this.txtchat.TabIndex = 40;
            // 
            // lstChatBox
            // 
            this.lstChatBox.FormattingEnabled = true;
            this.lstChatBox.Location = new System.Drawing.Point(661, 73);
            this.lstChatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstChatBox.Name = "lstChatBox";
            this.lstChatBox.Size = new System.Drawing.Size(280, 368);
            this.lstChatBox.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(175, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 460);
            this.panel1.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 460);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlHost
            // 
            this.pnlHost.BackColor = System.Drawing.Color.White;
            this.pnlHost.Location = new System.Drawing.Point(13, 15);
            this.pnlHost.Name = "pnlHost";
            this.pnlHost.Size = new System.Drawing.Size(142, 209);
            this.pnlHost.TabIndex = 49;
            // 
            // pnlGuest
            // 
            this.pnlGuest.BackColor = System.Drawing.Color.White;
            this.pnlGuest.Location = new System.Drawing.Point(13, 268);
            this.pnlGuest.Name = "pnlGuest";
            this.pnlGuest.Size = new System.Drawing.Size(142, 209);
            this.pnlGuest.TabIndex = 50;
            // 
            // LanGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 536);
            this.Controls.Add(this.pnlGuest);
            this.Controls.Add(this.pnlHost);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSanSang);
            this.Controls.Add(this.lblloi);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.txtchat);
            this.Controls.Add(this.lstChatBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LanGame";
            this.Text = "LanGame";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSanSang;
        private System.Windows.Forms.Label lblloi;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.TextBox txtchat;
        private System.Windows.Forms.ListBox lstChatBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlHost;
        private System.Windows.Forms.Panel pnlGuest;
    }
}