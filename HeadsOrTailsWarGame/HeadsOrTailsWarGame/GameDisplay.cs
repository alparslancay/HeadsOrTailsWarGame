using GameEntities;
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

        LinkedList<int> currentPlayersNumber = new LinkedList<int>();
        FinishController finishController;
        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
            buttonSelector = new ButtonSelector(currentButtons);
            warPlugin = new WarPlugin(currentButtons, gameMap.gameStates);
            finishController = new FinishController(gameMap.gameStates);

            for (int playerNumberRecorder = 0; playerNumberRecorder < numberPlayers; playerNumberRecorder++)
                currentPlayersNumber.AddLast(playerNumberRecorder);
        }

        private void NextPlayerTurn()
        {
            LinkedListNode<int> previousPlayerTurnNode = currentPlayersNumber.Find(GetSelectorPlayerNumber());

            LinkedListNode<int> currentPlayerNode = previousPlayerTurnNode.Next ?? previousPlayerTurnNode.List.First;

            lbl_PlayerTurn.Text = (currentPlayerNode.Value+1).ToString() + lbl_PlayerTurn.Text.Substring(1);

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
            if(selectorStateNumber == -1)
                MessageBox.Show("First, select your enemy areas!");
        }

        private void btn_CaptureAreas_Click(object sender, EventArgs e)
        {
            Stack<AreaSelectNode> requestedAreas = buttonSelector.GetTakeOverAreas();
            Stack<AreaSelectNode> betAreas = buttonSelector.GetSelectorBetAreas();
            if (requestedAreas.Count != 0 && requestedAreas.Count == betAreas.Count)
            {
                warPlugin.AreaRequest(GetSelectorPlayerNumber(), buttonSelector.GetSelectedStateNumber(), requestedAreas, betAreas);
                NextPlayerTurn();
                btn_SelectOtherStateAreas.PerformClick();
                SelectorStateStatementController(GetSelectorPlayerNumber(), buttonSelector.GetSelectedStateNumber());
                buttonSelector.ResetSelections();
            }

            else MessageBox.Show("Please Select More Areas!");
        }

        private void SelectorStateStatementController(int selectorPlayerNumber, int selectedStateNumber)
        {
            if (finishController.IsWinner(selectorPlayerNumber))
            {
                MessageBox.Show("Congratulations! You are winner!");
                Application.Exit();
            }

            else if (finishController.IsLoser(selectorPlayerNumber))
            {
                MessageBox.Show("You are defeat!");
                currentPlayersNumber.Remove(selectorPlayerNumber);
            }

            else SelectedStateStatementController(selectorStateNumber);
        }

        private void SelectedStateStatementController(int selectedStateNumber)
        {
            if (finishController.IsLoser(selectedStateNumber))
            {
                MessageBox.Show("You have defeated the" + gameMap.gameStates[selectedStateNumber].name + "state!");
                currentPlayersNumber.Remove(selectedStateNumber);
            }

        }
    }
}
