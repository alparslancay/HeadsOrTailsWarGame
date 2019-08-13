using GameEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFeatures
{
    public class GameCreater
    {
        LinkedList<int> currentPlayersNumber = new LinkedList<int>();

        Button[] currentAreas = new Button[900];
        public GameState[] gameStates;

        public void CreateMap(int numberPlayers, string[] stateNames)
        {
            CreateGameStates(numberPlayers, stateNames);
            CreateStateAreas(currentAreas, gameStates);
            const int FIRSTXCOORDINATE = 60;
            int xCoordinate = FIRSTXCOORDINATE;
            int yCoordinate = 0;

            for (int buttonRecorder = 0; buttonRecorder < currentAreas.Length; buttonRecorder++)
            {
                int playerNumber = FindPlayerNumberWithArea(numberPlayers, buttonRecorder);

                gameStates[playerNumber].ownedAreas.Add(buttonRecorder);

                CreateButtonProperties(buttonRecorder, xCoordinate, yCoordinate, StateFlag.GetFlag(playerNumber));


                if (xCoordinate - FIRSTXCOORDINATE >= 580)
                {
                    yCoordinate += 20;
                    xCoordinate = FIRSTXCOORDINATE;

                }
                else { xCoordinate += 20; }

            }
        }

        public Button[] GetGameAreas()
        {
            return currentAreas;
        }

        private void CreateGameStates(int numberPlayers, string [] stateNames)
        {
            gameStates = new GameState[numberPlayers];

            for (int playerRecorder = 0; playerRecorder < gameStates.Length; playerRecorder++)
            {
                GameState newGameState = new GameState
                {
                    name = stateNames[playerRecorder],
                    ownedAreas = new List<object>(),
                    flag = StateFlag.GetFlag(playerRecorder)
                };

            gameStates[playerRecorder] = newGameState;
            }
        }

        public void CreateStateAreas(Button[] currentAreas, GameState[] gameStates )
        {
            StateAreasDatas stateAreas = StateAreasDatas.GetStateAreasClass();
            stateAreas.CreateStateAreas(currentAreas, gameStates);
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

            currentAreas[buttonNumber] = gameButton;
        }

        private int FindPlayerNumberWithArea(int numberPlayers, int buttonNumber)
        {
            int aSidePlayerNumbers = (numberPlayers - numberPlayers % 2) / 2;

            int bSidePlayerNumbers = aSidePlayerNumbers + numberPlayers % 2;

            int aSideAreaPerRows = 30 / aSidePlayerNumbers;
            int bSideAreaPerRows = 30 / bSidePlayerNumbers;

            int bSideHorizontalLimit = 900 * bSidePlayerNumbers / (aSidePlayerNumbers + bSidePlayerNumbers);

            if(buttonNumber < bSideHorizontalLimit)
            {
                return buttonNumber % 30 / bSideAreaPerRows;
                
            }

            else
            {
                return (buttonNumber % 30 / aSideAreaPerRows) + bSidePlayerNumbers;
            }
        }
        
    }
}
