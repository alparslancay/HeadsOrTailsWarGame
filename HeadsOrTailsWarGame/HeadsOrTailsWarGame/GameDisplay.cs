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
        int selectorStateNumber;
        
        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
            buttonSelector = new ButtonSelector(currentButtons);
            warPlugin = new WarPlugin(currentButtons, gameMap.gameStates);
            
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

        //PlayerNumber starts from '0' so original value is more than the return value
        private int GetSelectorPlayerNumber()
        {
            string playerTurnNumber = lbl_PlayerTurn.Text[0].ToString();

            return Convert.ToInt16(playerTurnNumber) - 1;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button oldClickedButton = (Button)sender;
            if (selectorStateNumber == GetSelectorPlayerNumber())

                if (oldClickedButton.BackColor != Color.Black)
                    buttonSelector.SelectOtherStateArea(oldClickedButton, GetSelectorPlayerNumber());

                else MessageBox.Show("You already selected!");

            else 
     
                if (oldClickedButton.BackColor != Color.White)
                    buttonSelector.SelectSelectorStateArea(oldClickedButton, GetSelectorPlayerNumber());

                else MessageBox.Show("You already selected!");
            
        }

        private void btn_SelectOtherStateAreas_Click(object sender, EventArgs e)
        {
            selectorStateNumber = GetSelectorPlayerNumber();
        }

        private void btn_SelectSelectorAreas_Click(object sender, EventArgs e)
        {
            selectorStateNumber = buttonSelector.GetSelectedStateNumber();
        }

        private void btn_CaptureAreas_Click(object sender, EventArgs e)
        {
            Stack<ButtonInformationSaver> requestedAreas = buttonSelector.GetTakeOverAreas();
            Stack<ButtonInformationSaver> betAreas = buttonSelector.GetSelectorBetAreas();
            if (requestedAreas.Count != 0 && requestedAreas.Count == betAreas.Count)
            {
                warPlugin.AreaRequest(GetSelectorPlayerNumber(), buttonSelector.GetSelectedStateNumber(), requestedAreas, betAreas);
                buttonSelector.ResetSelections();
                NextPlayerTurn();
                btn_SelectOtherStateAreas.PerformClick();
            }

            else MessageBox.Show("Please Select More Areas!");
        }
    }
}
