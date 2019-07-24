using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRules
{
    public class StatesBoundary
    {
        private int numberPlayers;
        private const int AREA_SIZE = 900;

        public StatesBoundary(int numberPlayers)
        {
            this.numberPlayers = numberPlayers;
        }

        public void CreateFirstBorders()
        {

            for (int stateRecorder = 0; stateRecorder < numberPlayers-1; stateRecorder++)
            {

            }
        }

    }
}
