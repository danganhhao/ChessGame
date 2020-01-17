namespace ChessGame
{
    partial class frmFindGame
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
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.btnHostGame = new System.Windows.Forms.Button();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblHostIP = new System.Windows.Forms.Label();
            this.txtHostVal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJoinGame.Location = new System.Drawing.Point(252, 164);
            this.btnJoinGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(116, 51);
            this.btnJoinGame.TabIndex = 17;
            this.btnJoinGame.Text = "Vào phòng chơi";
            this.btnJoinGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJoinGame.UseVisualStyleBackColor = true;
            this.btnJoinGame.Click += new System.EventHandler(this.btnJoinGame_Click);
            // 
            // btnHostGame
            // 
            this.btnHostGame.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHostGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHostGame.Location = new System.Drawing.Point(252, 50);
            this.btnHostGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHostGame.Name = "btnHostGame";
            this.btnHostGame.Size = new System.Drawing.Size(116, 51);
            this.btnHostGame.TabIndex = 16;
            this.btnHostGame.Text = "Tạo phòng chơi";
            this.btnHostGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHostGame.UseVisualStyleBackColor = true;
            this.btnHostGame.Click += new System.EventHandler(this.btnHostGame_Click);
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(12, 119);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(64, 17);
            this.lblIP.TabIndex = 23;
            this.lblIP.Text = "IP phòng";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(92, 119);
            this.txtIP.Name = "txtIP";
            this.txtIP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIP.Size = new System.Drawing.Size(297, 22);
            this.txtIP.TabIndex = 18;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(408, 119);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 17);
            this.lblPort.TabIndex = 24;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(448, 119);
            this.txtPort.Name = "txtPort";
            this.txtPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPort.Size = new System.Drawing.Size(142, 22);
            this.txtPort.TabIndex = 25;
            // 
            // lblHostIP
            // 
            this.lblHostIP.AutoSize = true;
            this.lblHostIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostIP.Location = new System.Drawing.Point(12, 19);
            this.lblHostIP.Name = "lblHostIP";
            this.lblHostIP.Size = new System.Drawing.Size(53, 17);
            this.lblHostIP.TabIndex = 26;
            this.lblHostIP.Text = "IP Host";
            // 
            // txtHostVal
            // 
            this.txtHostVal.Location = new System.Drawing.Point(92, 14);
            this.txtHostVal.Name = "txtHostVal";
            this.txtHostVal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHostVal.Size = new System.Drawing.Size(297, 22);
            this.txtHostVal.TabIndex = 28;
            // 
            // frmFindGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 241);
            this.Controls.Add(this.txtHostVal);
            this.Controls.Add(this.lblHostIP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnJoinGame);
            this.Controls.Add(this.btnHostGame);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFindGame";
            this.Text = "frmFindGame";
            this.Load += new System.EventHandler(this.frmFindGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Button btnHostGame;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblHostIP;
        private System.Windows.Forms.TextBox txtHostVal;
    }
}