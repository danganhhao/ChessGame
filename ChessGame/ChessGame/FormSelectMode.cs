﻿using ChessGame.Data;
using ChessGame.ResourceManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class FormSelectMode : Form
    {
        GameManager gameManager = GameManager.GetInstance();
        int[] times = new int[] { 5, 10, 30 };
        int[] skins = new int[] { 0, 1 , 2};
        public FormSelectMode()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (NotChooseSomething())
            {
                ShowMessage("Please choose mode, color and time");
                return;
            }
            GameMode mode = this.GetGameMode();
            PieceSide side = this.GetSide();
            int time = this.GetTime();
            this.gameManager.Mode = mode;
            this.gameManager.MySide = side;
            this.gameManager.Time = time * 60;
            int skin = this.GetSkin();
            UpdatePieceSkin(skin);

            if (mode != GameMode.OnLan)
            {
                this.Hide();
                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else
            {
                this.Hide();
                var form1 = new frmFindGame();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
        }

        private void UpdatePieceSkin(int skin)
        {
            switch (skin)
            {
                case 0: ResourceModule.GetInstance().UpdatePieceResource(new BasicPiece()); break;
                case 1: ResourceModule.GetInstance().UpdatePieceResource(new ColorfulPiece()); break;
                case 2: ResourceModule.GetInstance().UpdatePieceResource(new _3DPiece()); break;
                default :
                    ResourceModule.GetInstance().UpdatePieceResource(new BasicPiece()); break;
            }
        }

        private int GetTime()
        {
            int index = cboListTime.SelectedIndex;
            return this.times[index];
        }

        private int GetSkin()
        {
            int index = cboSkin.SelectedIndex;
            if (index < 0)
                return this.skins[0];
            else
                return this.skins[index];
        }

        private bool NotChooseSomething()
        {
            return cboListMode.SelectedIndex < 0 || cboListMode.SelectedIndex < 0 || cboListColor.SelectedIndex < 0;
        }

        private PieceSide GetSide()
        {
            return (PieceSide)cboListColor.SelectedIndex;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private GameMode GetGameMode()
        {
            return (GameMode)cboListMode.SelectedIndex;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboListTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
