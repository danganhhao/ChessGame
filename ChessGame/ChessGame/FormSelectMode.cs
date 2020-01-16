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
            GameMode mode = this.GetGameMode();
            this.gameManager.Mode = mode;
            if (mode != GameMode.OnLan)
            {
                Application.Run(new Form1());
            }
        }

        private GameMode GetGameMode()
        {
            return (GameMode)cboListMode.SelectedIndex;
        }
    }
}
