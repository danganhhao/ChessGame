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
            this.components = new System.ComponentModel.Container();
            this.lstHost = new System.Windows.Forms.ListView();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.btnHostGame = new System.Windows.Forms.Button();
            this.lblRoomList = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.timerSendBroadcast = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateHost = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lstHost
            // 
            this.lstHost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHost.FullRowSelect = true;
            this.lstHost.GridLines = true;
            this.lstHost.HideSelection = false;
            this.lstHost.Location = new System.Drawing.Point(25, 47);
            this.lstHost.MultiSelect = false;
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(206, 360);
            this.lstHost.TabIndex = 21;
            this.lstHost.UseCompatibleStateImageBehavior = false;
            this.lstHost.View = System.Windows.Forms.View.Tile;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(605, 235);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(64, 22);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "G&ửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.Location = new System.Drawing.Point(253, 272);
            this.lstChat.Name = "lstChat";
            this.lstChat.ScrollAlwaysVisible = true;
            this.lstChat.Size = new System.Drawing.Size(416, 134);
            this.lstChat.TabIndex = 19;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(253, 235);
            this.txtChat.Name = "txtChat";
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(346, 22);
            this.txtChat.TabIndex = 18;
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJoinGame.Location = new System.Drawing.Point(385, 107);
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
            this.btnHostGame.Location = new System.Drawing.Point(263, 107);
            this.btnHostGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHostGame.Name = "btnHostGame";
            this.btnHostGame.Size = new System.Drawing.Size(116, 51);
            this.btnHostGame.TabIndex = 16;
            this.btnHostGame.Text = "Tạo phòng chơi";
            this.btnHostGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHostGame.UseVisualStyleBackColor = true;
            this.btnHostGame.Click += new System.EventHandler(this.btnHostGame_Click);
            // 
            // lblRoomList
            // 
            this.lblRoomList.AutoSize = true;
            this.lblRoomList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomList.Location = new System.Drawing.Point(22, 27);
            this.lblRoomList.Name = "lblRoomList";
            this.lblRoomList.Size = new System.Drawing.Size(116, 17);
            this.lblRoomList.TabIndex = 22;
            this.lblRoomList.Text = "Danh sách phòng";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(250, 215);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(120, 17);
            this.lblMsg.TabIndex = 23;
            this.lblMsg.Text = "Gửi tin nhắn LAN:";
            // 
            // timerSendBroadcast
            // 
            this.timerSendBroadcast.Tick += new System.EventHandler(this.timerSendBroadcast_Tick);
            // 
            // timerUpdateHost
            // 
            this.timerUpdateHost.Tick += new System.EventHandler(this.timerUpdateHost_Tick);
            // 
            // frmFindGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 419);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblRoomList);
            this.Controls.Add(this.lstHost);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.txtChat);
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

        private System.Windows.Forms.ListView lstHost;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Button btnHostGame;
        private System.Windows.Forms.Label lblRoomList;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timerSendBroadcast;
        private System.Windows.Forms.Timer timerUpdateHost;
    }
}