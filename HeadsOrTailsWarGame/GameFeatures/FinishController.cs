using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public class FinishController
    {
        GameStates[] gameStates;

        public FinishController(GameStates[] gameStates)
        {
            this.gameStates = gameStates;
        }

        public bool IsWinner(int stateNumber)
        {
            return gameStates[stateNumber].OwnedArea.Count == 900;
        }

        public bool IsLoser(int stateNumber)
        {
            return gameStates[stateNumber].OwnedArea.Count == 0;
        }
    }
}
