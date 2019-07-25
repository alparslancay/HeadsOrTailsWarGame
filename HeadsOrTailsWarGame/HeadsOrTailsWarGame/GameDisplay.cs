using GameFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadsOrTailsWarGame
{
    public partial class GameDisplay : Form
    {
        public GameDisplay()
        {
            InitializeComponent();
        }

        StateBorders stateBorders = new StateBorders();
        Button[] currentButtons;
        int playerSize = 6;

        Stack<Button> selectedButtons = new Stack<Button>();

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.BackColor != Color.Black)
                selectedButtons.Push(clickedButton);


            clickedButton.BackColor = Color.Black;

            MessageBox.Show(clickedButton.Name);
        }

        private void ConvertToOldButtons()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            while (selectedButtons.Count != 0)
            {
                MessageBox.Show(selectedButtons.Pop().Name);
            }
        }

        private void CreateButtons()
        {
            currentButtons = stateBorders.CreateButtons();

            foreach (var currentButton in currentButtons)
            {
                currentButton.Click += new EventHandler(ButtonClick);
                Controls.Add(currentButton);
            }
        }

    }
}
