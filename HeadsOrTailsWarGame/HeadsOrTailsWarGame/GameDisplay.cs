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
        public GameDisplay(int numberPlayers)
        {
            InitializeComponent();

            this.numberPlayers = numberPlayers;
        }

        WarPlugin warPlugin;
        GameMap gameMap = new GameMap();
        Button[] currentButtons;
        ButtonSelector buttonSelector;
        int numberPlayers;
        
        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
            buttonSelector = new ButtonSelector(currentButtons);
            warPlugin = new WarPlugin(currentButtons, gameMap.gameStates);
            
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button oldClickedButton = (Button)sender;
            
            if (oldClickedButton.BackColor != Color.Black)
            {
                buttonSelector.SelectButton(oldClickedButton, GetSelectorPlayerNumber());
            }

        }
        //PlayerNumber starts from '0' so original value is more than the return value
        private int GetSelectorPlayerNumber()
        {
            string playerTurnNumber = lbl_PlayerTurn.Text[0].ToString();

            return Convert.ToInt16(playerTurnNumber)-1;
        }

        private void NextPlayerTurn()
        {
            int currentPlayerTurnNumber = GetSelectorPlayerNumber();

            currentPlayerTurnNumber++;

            if(currentPlayerTurnNumber < numberPlayers)
            lbl_PlayerTurn.Text = (++currentPlayerTurnNumber).ToString() + lbl_PlayerTurn.Text.Substring(1);

            else lbl_PlayerTurn.Text = (1).ToString() + lbl_PlayerTurn.Text.Substring(1);


        }
        
        private string[] GetDefaultStateName(int numberPlayers)
        {
            StateColor stateColor = new StateColor();

            string[] stateNames = new string[numberPlayers];

            for (int stateNameRecorder = 0; stateNameRecorder < stateNames.Length; stateNameRecorder++)
            {
                stateNames[stateNameRecorder] = stateColor.GetColor(stateNameRecorder).Name;
            }

            return stateNames;
        }

        private void CreateButtons()
        {
            currentButtons = gameMap.CreateMap(numberPlayers,GetDefaultStateName(numberPlayers));

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

            if (requestedAreas.Count != 0)
            {
                warPlugin.AreaRequest(GetSelectorPlayerNumber(), requestedAreas.First().ownedPlayerNumber, requestedAreas);
                buttonSelector.ResetSelections();
                NextPlayerTurn();
            }

            else MessageBox.Show("Please Select Areas!");
        }
    }
}
