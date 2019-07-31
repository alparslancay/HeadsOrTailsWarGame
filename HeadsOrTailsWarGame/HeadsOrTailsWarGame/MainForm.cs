using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadsOrTailsWarGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            if (cmb_NumberPlayers.Text != "")
            {
                GameDisplay gameDisplay = new GameDisplay(int.Parse(cmb_NumberPlayers.Text));
                gameDisplay.ShowDialog();
            }

            else MessageBox.Show("Please choose number of players!");
        }
        
    }
}
