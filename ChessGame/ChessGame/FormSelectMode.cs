using ChessGame.Data;
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
        public FormSelectMode()
        {
            InitializeComponent();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cboListMode.SelectedIndex < 0 || cboListMode.SelectedIndex < 0)
            {
                ShowMessage("Please choose mode and color");
                return;
            }
            GameMode mode = this.GetGameMode();
            PieceSide side = this.GetSide();
            this.gameManager.Mode = mode;
            this.gameManager.MySide = side;

            if (mode != GameMode.OnLan)
            {
                this.Hide();
                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else Application.Run(new frmFindGame());
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
    }
}
