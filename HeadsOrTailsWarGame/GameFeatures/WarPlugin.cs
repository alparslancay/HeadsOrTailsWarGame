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
        GameStates[] gameStates;
        Stack<ButtonInformationSaver> loseAnnexStateAreas;

        public WarPlugin(Button [] stateButtons, GameStates [] gameStates)
        {
            currentButtons = stateButtons;
            this.gameStates = gameStates;
        }

        public void AreaRequest(int requestingStateNumber, int requestedStateNumber, Stack<ButtonInformationSaver> selectedAreas)
        {
            if (IsWinner())
            {
                AnnexAreas(requestingStateNumber, requestedStateNumber, selectedAreas);
            }

            else
            {
                AnnexAreas(requestedStateNumber, requestingStateNumber, GetLoseAnnexStateAreas(requestingStateNumber,selectedAreas.Count));
            }
        }

        private bool IsWinner()
        {
            Random random = new Random();
            return 1 == random.Next(0, 2);

        }

        private void AnnexAreas(int annextationStateNumber, int requestedStateNumber, Stack<ButtonInformationSaver> annexedAreas)
        {

            while (annexedAreas.Count != 0)
            {

                ButtonInformationSaver oldAreaProperties = annexedAreas.Pop();
                currentButtons[oldAreaProperties.buttonNumber].BackColor = stateColor.GetColor(annextationStateNumber);

                gameStates[annextationStateNumber].OwnedArea.Add(oldAreaProperties.buttonNumber);
                gameStates[requestedStateNumber].OwnedArea.Remove(oldAreaProperties.buttonNumber);
            }
        }

        private Stack<ButtonInformationSaver> GetLoseAnnexStateAreas(int loseAnnexStateNumber, int numberAreas)
        {
            loseAnnexStateAreas = new Stack<ButtonInformationSaver>();

            Random randomAreaIndexFinder = new Random();

            while (numberAreas != 0)
            {
                int areaIndex = randomAreaIndexFinder.Next(0, gameStates[loseAnnexStateNumber].OwnedArea.Count);

                int areaNumber = gameStates[loseAnnexStateNumber].OwnedArea[areaIndex];


                ButtonInformationSaver saverButton = new ButtonInformationSaver()
                {
                    currentColor = stateColor.GetColor(loseAnnexStateNumber),
                    buttonNumber = areaNumber
                };

                gameStates[loseAnnexStateNumber].OwnedArea.Remove(areaNumber);

                loseAnnexStateAreas.Push(saverButton);

                numberAreas--;
            }

            return loseAnnexStateAreas;
            
        }
    }
}
