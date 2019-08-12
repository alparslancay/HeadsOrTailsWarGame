using GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFeatures
{
    public class WarPlugin
    {
        Button[] currentButtons;
        StateColor stateColor = new StateColor();
        GameState[] gameStates;

        public WarPlugin(Button[] stateButtons, GameState[] gameStates)
        {
            currentButtons = stateButtons;
            this.gameStates = gameStates;
        }

        public void AreaRequest(int requestingStateNumber, int requestedStateNumber, Stack<AreaSelectNode> selectedTakeOverAreas, Stack<AreaSelectNode> selectorBetAreas)
        {
            if (IsWinner())
            {
                AnnexAreas(requestingStateNumber, requestedStateNumber, selectedTakeOverAreas);
            }

            else
            {
                AnnexAreas(requestedStateNumber, requestingStateNumber, selectorBetAreas);
            }
        }

        private bool IsWinner()
        {
            Random random = new Random();
            return 1 == random.Next(0, 2);

        }

        private void AnnexAreas(int annextationStateNumber, int requestedStateNumber, Stack<AreaSelectNode> annexedAreas)
        {

            while (annexedAreas.Count != 0)
            {

                AreaSelectNode oldAreaNode = annexedAreas.Pop();
                currentButtons[oldAreaNode.areaNumber].BackColor = stateColor.GetColor(annextationStateNumber);

                gameStates[annextationStateNumber].ownedAreas.Add(oldAreaNode.areaNumber);
                gameStates[requestedStateNumber].ownedAreas.Remove(oldAreaNode.areaNumber);
            }
        }
    }
}