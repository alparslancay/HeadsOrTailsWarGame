using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFeatures
{
    public class ButtonSelector
    {
        Stack<ButtonInformationSaver> selectedTakeOverAreasInformations = new Stack<ButtonInformationSaver>();
        Stack<ButtonInformationSaver> selectorBetAreaInformations = new Stack<ButtonInformationSaver>();
        StateAreas stateAreas = StateAreas.GetStateAreasClass();

        Button[] currentButtons;

        StateColor stateColor = new StateColor();

        public ButtonSelector(Button [] stateButtons)
        {
            currentButtons = stateButtons;
        }

        private bool StackIsEmpty()
        {
            return selectedTakeOverAreasInformations.Count == 0;
        }
        
        public void SelectOtherStateArea(Button oldClickedButton, int selectorPlayerNumber)
        {
            if (!IsSelectorPlayerState(oldClickedButton, selectorPlayerNumber))

                if (!IsStateOfAnotherEnemyPlayer(oldClickedButton))

                    if (IsAreaAdjacent(oldClickedButton, selectorPlayerNumber, selectedTakeOverAreasInformations))
                    {

                        ButtonInformationSaver saverButton = new ButtonInformationSaver()
                        {
                            ownedPlayerNumber = stateColor.GetPlayerNumberWithColor(oldClickedButton.BackColor),
                            currentColor = oldClickedButton.BackColor,
                            buttonNumber = int.Parse(oldClickedButton.Name)
                        };

                        selectedTakeOverAreasInformations.Push(saverButton);

                        oldClickedButton.BackColor = Color.Black;
                    }
                    else MessageBox.Show("You can only select adjacent areas!");

                else MessageBox.Show("You can not select from another state!");

            else MessageBox.Show("You can not select your state!");

        }

        public void SelectSelectorStateArea(Button oldClickedButton, int selectorPlayerNumber)
        {
            int selectedStateNumber = selectedTakeOverAreasInformations.First().ownedPlayerNumber;

            if (IsSelectorPlayerState(oldClickedButton, selectorPlayerNumber))

                if (IsAreaAdjacent(oldClickedButton, selectedStateNumber, selectorBetAreaInformations))
                {

                    ButtonInformationSaver saverButton = new ButtonInformationSaver()
                    {
                        ownedPlayerNumber = stateColor.GetPlayerNumberWithColor(oldClickedButton.BackColor),
                        currentColor = oldClickedButton.BackColor,
                        buttonNumber = int.Parse(oldClickedButton.Name)
                    };

                    selectorBetAreaInformations.Push(saverButton);

                    oldClickedButton.BackColor = Color.White;
                }
                else MessageBox.Show("You can only select adjacent areas!");

            else MessageBox.Show("You have to select your state!");

        }

        public void RemoveTakeOverArea(Button selectedButton)
        {
            Stack<ButtonInformationSaver> currentTakeOverAreasInformations = new Stack<ButtonInformationSaver>();

            foreach (var currentAreaInformations in selectedTakeOverAreasInformations)
            {
                if (currentAreaInformations.buttonNumber != int.Parse(selectedButton.Name))
                    currentTakeOverAreasInformations.Push(currentAreaInformations);
            }

            selectedTakeOverAreasInformations = currentTakeOverAreasInformations;
        }

        public void RemoveBetArea(Button selectedButton)
        {
            Stack<ButtonInformationSaver> currentBetAreasInformations = new Stack<ButtonInformationSaver>();

            foreach (var currentAreaInformations in selectorBetAreaInformations)
            {
                if (currentAreaInformations.buttonNumber != int.Parse(selectedButton.Name))
                    currentBetAreasInformations.Push(currentAreaInformations);
            }

            selectedTakeOverAreasInformations = currentBetAreasInformations;
        }

        public Stack<ButtonInformationSaver> GetTakeOverAreas()
        {
            return selectedTakeOverAreasInformations;
        }

        public Stack<ButtonInformationSaver> GetSelectorBetAreas()
        {
            return selectorBetAreaInformations;
        }


        private bool IsSelectorPlayerState(Button oldClickedButton, int selectorPlayerNumber)
        {
            return oldClickedButton.BackColor == stateColor.GetColor(selectorPlayerNumber);
        }

        private bool IsStateOfAnotherEnemyPlayer(Button oldClickedButton)
        {
            return !StackIsEmpty() && oldClickedButton.BackColor != selectedTakeOverAreasInformations.First().currentColor;
        }
        
        private bool IsAreaAdjacent(Button currentArea, int stateNumber, Stack<ButtonInformationSaver> selectedAreas)
        {
            if (selectedAreas.Count == 0)
                return stateAreas.IsAdjacentToTheAreas(currentArea, stateAreas.GetStateEndZones(stateNumber));

            else
            {
                List<Button> selectedAreasList = new List<Button>();

                foreach (var currentSelectedAreaInformation in selectedAreas)
                {
                    selectedAreasList.Add(currentButtons[currentSelectedAreaInformation.buttonNumber]);
                }

                return stateAreas.IsAdjacentToTheSelectedAreas(currentArea,selectedAreasList);
            }
            
        }
        
        public void ResetSelections()
        {
            while (selectedTakeOverAreasInformations.Count != 0)
            {
                ButtonInformationSaver oldButtonProperties = selectedTakeOverAreasInformations.Pop();
                currentButtons[oldButtonProperties.buttonNumber].BackColor = oldButtonProperties.currentColor;
            }

            while(selectorBetAreaInformations.Count != 0)
            {
                ButtonInformationSaver oldButtonProperties = selectorBetAreaInformations.Pop();
                currentButtons[oldButtonProperties.buttonNumber].BackColor = oldButtonProperties.currentColor;
            }
        }

        public int GetSelectedStateNumber()
        {
            return selectedTakeOverAreasInformations.First().ownedPlayerNumber;
        }
    }
}
