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

        WarPlugin warPlugin;
        GameMap gameMap = new GameMap();
        Button[] currentButtons;
        ButtonSelector buttonSelector;

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
            buttonSelector = new ButtonSelector(currentButtons);
            warPlugin = new WarPlugin(currentButtons, gameMap.gamePlayers);
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
            currentButtons = gameMap.CreateMap(DeleteFuture_TestNumberPlayers(),DeleteFuture_TestStateName());

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

        private void btn_CaptureAreas_Click(object sender, EventArgs e)
        {
            Stack<ButtonInformationSaver> requestedAreas = buttonSelector.GetSelectedAreas();
            
            warPlugin.AreaRequest(DeleteFuture_TestSelectorNumber(), requestedAreas.First().ownedPlayerNumber, requestedAreas);
            buttonSelector.ResetSelections();
        }
    }
}
