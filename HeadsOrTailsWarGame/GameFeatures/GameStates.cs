using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFeatures
{
    public class GameStates
    {
        Button[] currentButtons = new Button[900];
        StateColor stateColor = new StateColor();

        public GamePlayer[] gamePlayers;

        public Button[] CreateMap(int numberPlayers, string[] stateNames)
        {
            gamePlayers = CreateGamePlayers(numberPlayers, stateNames);

            for (int playerRecorder = 0; playerRecorder < gamePlayers.Length; playerRecorder++)
            {

            }

            const int FIRSTXCOORDINATE = 60;
            int xCoordinate = FIRSTXCOORDINATE;
            int yCoordinate = 0;

            for (int buttonRecorder = 0; buttonRecorder < currentButtons.Length; buttonRecorder++)
            {
                int playerNumber = FindPlayerNumberWithArea(numberPlayers, buttonRecorder);

                gamePlayers[playerNumber].OwnedArea.Add(buttonRecorder);

                CreateButtonProperties(buttonRecorder, xCoordinate, yCoordinate, stateColor.TakeColor(playerNumber));


                if (xCoordinate - FIRSTXCOORDINATE >= 580)
                {
                    yCoordinate += 20;
                    xCoordinate = FIRSTXCOORDINATE;

                }
                else { xCoordinate += 20; }

            }

            return currentButtons;
        }

        private GamePlayer[] CreateGamePlayers(int numberPlayers, string [] stateNames)
        {
            gamePlayers = new GamePlayer[numberPlayers];

            for (int playerRecorder = 0; playerRecorder < gamePlayers.Length; playerRecorder++)
            {
                GamePlayer newGamePlayer = new GamePlayer
                {
                    StateName = stateNames[playerRecorder],
                    OwnedArea = new List<int>()
                };

            gamePlayers[playerRecorder] = newGamePlayer;
            }

            return gamePlayers;
        }

        private void CreateButtonProperties(int buttonNumber, int xCoordinate, int yCoordinate, Color buttonColor)
        {
            Button gameButton = new Button
            {
                Size = new Size(20, 20),
                Location = new Point(xCoordinate, yCoordinate),
                BackColor = buttonColor,
                Name = buttonNumber.ToString()
            };

            currentButtons[buttonNumber] = gameButton;
        }

        private int FindPlayerNumberWithArea(int numberPlayers, int buttonNumber)
        {
            int aSidePlayerNumbers = (numberPlayers - numberPlayers % 2) / 2;
            int bSidePlayerNumbers = aSidePlayerNumbers + numberPlayers % 2;

            int aSideAreaPerRows = 30 / aSidePlayerNumbers;
            int bSideAreaPerRows = 30 / bSidePlayerNumbers;

            if(buttonNumber < 450)
            {
                return buttonNumber % 30 / bSideAreaPerRows;
                
            }

            else
            {
                return (buttonNumber % 30 / aSideAreaPerRows) + aSidePlayerNumbers;
            }
        }
    }
}
