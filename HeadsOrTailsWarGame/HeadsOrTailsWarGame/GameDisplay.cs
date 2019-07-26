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

        GameStates stateBorders = new GameStates();
        Button[] currentButtons;

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

        private int DeleteFuture_TestNumberPlayers()
        {
            return 6;
        }

        private string[] DeleteFuture_TestStateName()
        {
            return new string[6] { "1", "2", "3", "4", "5", "6" };
        }

        private void CreateButtons()
        {
            currentButtons = stateBorders.CreateMap(DeleteFuture_TestNumberPlayers(),DeleteFuture_TestStateName());

            foreach (var currentButton in currentButtons)
            {
                currentButton.Click += new EventHandler(ButtonClick);
                Controls.Add(currentButton);
            }
            
        }

    }
}
