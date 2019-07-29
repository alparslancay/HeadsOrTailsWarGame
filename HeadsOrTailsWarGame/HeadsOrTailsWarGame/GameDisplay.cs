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
        ButtonSelector buttonSelector;

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
            buttonSelector = new ButtonSelector(currentButtons);
        }
        
        private int DeleteFuture_TestSelectorNumber()
        {
            return 1;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button oldClickedButton = (Button)sender;
            
            if (oldClickedButton.BackColor != Color.Black)
            {
                buttonSelector.SelectButton(oldClickedButton, DeleteFuture_TestSelectorNumber());
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

        private void btn_ResetSelections_Click(object sender, EventArgs e)
        {
            buttonSelector.ResetSelections();
        }
    }
}
