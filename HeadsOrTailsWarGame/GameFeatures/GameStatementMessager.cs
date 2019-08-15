using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public static class GameStatementMessager
    {
        public static string statementMessage;

        public static void WinMessage(string winnerName)
        {
            statementMessage = winnerName + " has won!";
        }

        public static void LoseMessage(string loserName)
        {
            statementMessage = loserName + " has lost!";
        }
    }
}
