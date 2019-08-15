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
        GameOperations gameOperations;
        int numberPlayers;
        private void GameDisplay_Load(object sender, EventArgs e)
        {
            gameOperations = new GameOperations(numberPlayers);

            CreateAreasInUI();
        }

        private void NextStateTurn()
        {
            gameOperations.NextTurn();
            lbl_StateTurn.Text = (gameOperations.GetSelectorNumber()+1).ToString()+".State's Turn";

        }

        private void CreateAreasInUI()
        {
            foreach (var currentArea in gameOperations.gameCreater.GetGameAreas())
            {
                currentArea.Click += new EventHandler(ButtonClick);
                Controls.Add(currentArea);
            }
            
        }

        private void btn_ResetSelections_Click(object sender, EventArgs e)
        {
            gameOperations.ResetSelections();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if(!gameOperations.SelectTheArea(sender))
                MessageBox.Show(WarningMessager.warningMessage);

        }

        private void btn_SelectOtherStateAreas_Click(object sender, EventArgs e)
        {
            gameOperations.ChangeSelectingAreaStateNumber(true);
        }

        private void btn_SelectSelectorAreas_Click(object sender, EventArgs e)
        {
            gameOperations.ChangeSelectingAreaStateNumber(false);
            if (gameOperations.GetSelectingAreaStateNumber() == -1)
                MessageBox.Show("First, select your enemy areas!");
        }

        private void btn_CaptureAreas_Click(object sender, EventArgs e)
        {
            if (gameOperations.TryCaptureAreas())
            {
                CheckGameStatement();
                NextStateTurn();
                btn_SelectOtherStateAreas.PerformClick();
            }

            else
            MessageBox.Show(WarningMessager.warningMessage);
        }

        private void CheckGameStatement()
        {
            do
            {
                if (gameOperations.IsThereLoser())
                {
                    MessageBox.Show(GameStatementMessager.statementMessage);
                    break;
                }
                if (gameOperations.IsThereWinner())
                {
                    MessageBox.Show(GameStatementMessager.statementMessage);
                    Application.Exit();
                    break;
                }
            } while (false);

        }

    }
}
