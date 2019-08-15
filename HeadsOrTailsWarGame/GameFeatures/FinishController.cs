using GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public class FinishController
    {
        GameState[] gameStates;

        public FinishController(GameState[] gameStates)
        {
            this.gameStates = gameStates;
        }

        public bool IsWinner(int stateNumber)
        {
            if (gameStates[stateNumber].ownedAreas.Count == 900)
            {
                GameStatementMessager.WinMessage(gameStates[stateNumber].name);
                return true;
            }

            else return false;
        }

        public bool IsLoser(int stateNumber)
        {
            if (gameStates[stateNumber].ownedAreas.Count == 0)
            {
                GameStatementMessager.LoseMessage(gameStates[stateNumber].name);
                return true;
            }

            else return false;
        }
    }
}
