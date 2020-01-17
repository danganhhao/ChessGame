namespace ChessGame
{
    partial class FormSelectMode
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboListMode = new System.Windows.Forms.ComboBox();
            this.cboListColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cboListTime = new System.Windows.Forms.ComboBox();
            this.lblChooseTime = new System.Windows.Forms.Label();
            this.cboSkin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Mode";
            // 
            // cboListMode
            // 
            this.cboListMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListMode.FormattingEnabled = true;
            this.cboListMode.Items.AddRange(new object[] {
            "2 Player",
            "Play with Computer",
            "Play on LAN"});
            this.cboListMode.Location = new System.Drawing.Point(96, 108);
            this.cboListMode.Name = "cboListMode";
            this.cboListMode.Size = new System.Drawing.Size(202, 28);
            this.cboListMode.TabIndex = 1;
            // 
            // cboListColor
            // 
            this.cboListColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListColor.FormattingEnabled = true;
            this.cboListColor.Items.AddRange(new object[] {
            "Black",
            "White"});
            this.cboListColor.Location = new System.Drawing.Point(96, 195);
            this.cboListColor.Name = "cboListColor";
            this.cboListColor.Size = new System.Drawing.Size(202, 28);
            this.cboListColor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose Color";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Welcom to chess piece game";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(154, 429);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 33);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Next";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cboListTime
            // 
            this.cboListTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListTime.FormattingEnabled = true;
            this.cboListTime.Items.AddRange(new object[] {
            "5 minutes",
            "10 minutes",
            "30 minutes"});
            this.cboListTime.Location = new System.Drawing.Point(96, 280);
            this.cboListTime.Name = "cboListTime";
            this.cboListTime.Size = new System.Drawing.Size(202, 28);
            this.cboListTime.TabIndex = 7;
            this.cboListTime.SelectedIndexChanged += new System.EventHandler(this.cboListTime_SelectedIndexChanged);
            // 
            // lblChooseTime
            // 
            this.lblChooseTime.AutoSize = true;
            this.lblChooseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseTime.Location = new System.Drawing.Point(93, 248);
            this.lblChooseTime.Name = "lblChooseTime";
            this.lblChooseTime.Size = new System.Drawing.Size(108, 20);
            this.lblChooseTime.TabIndex = 6;
            this.lblChooseTime.Text = "Choose Time";
            // 
            // cboSkin
            // 
            this.cboSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSkin.FormattingEnabled = true;
            this.cboSkin.Items.AddRange(new object[] {
            "Default",
            "Colorful",
            "3D"});
            this.cboSkin.Location = new System.Drawing.Point(97, 367);
            this.cboSkin.Name = "cboSkin";
            this.cboSkin.Size = new System.Drawing.Size(202, 28);
            this.cboSkin.TabIndex = 9;
            this.cboSkin.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Choose Skin Piece";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // FormSelectMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 484);
            this.Controls.Add(this.cboSkin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboListTime);
            this.Controls.Add(this.lblChooseTime);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboListColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboListMode);
            this.Controls.Add(this.label1);
            this.Name = "FormSelectMode";
            this.Text = "FormSelectMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboListMode;
        private System.Windows.Forms.ComboBox cboListColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cboListTime;
        private System.Windows.Forms.Label lblChooseTime;
        private System.Windows.Forms.ComboBox cboSkin;
        private System.Windows.Forms.Label label4;
    }
}