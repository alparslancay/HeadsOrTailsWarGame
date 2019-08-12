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
            return gameStates[stateNumber].ownedAreas.Count == 900;
        }

        public bool IsLoser(int stateNumber)
        {
            return gameStates[stateNumber].ownedAreas.Count == 0;
        }
    }
}
