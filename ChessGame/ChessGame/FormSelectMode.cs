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
        int[] times = new int[] { 5, 10, 30 };
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

        private int GetTime()
        {
            int index = cboListTime.SelectedIndex;
            return this.times[index];
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
    }
}
