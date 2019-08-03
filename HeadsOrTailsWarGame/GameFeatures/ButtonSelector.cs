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
        Stack<ButtonInformationSaver> selectedButtonInformations = new Stack<ButtonInformationSaver>();
        StateAreas stateAreas = StateAreas.GetStateAreasClass();

        Button[] currentButtons;

        StateColor stateColor = new StateColor();

        public ButtonSelector(Button [] stateButtons)
        {
            currentButtons = stateButtons;
        }

        private bool StackIsEmpty()
        {
            return selectedButtonInformations.Count == 0;
        }
        
        public void SelectButton(Button oldClickedButton, int selectorPlayerNumber)
        {
            if (!IsSelectorPlayerState(oldClickedButton, selectorPlayerNumber))

                if (!IsStateOfAnotherEnemyPlayer(oldClickedButton))

                    if (IsAreaAdjacent(oldClickedButton, selectorPlayerNumber))
                    {

                        ButtonInformationSaver saverButton = new ButtonInformationSaver()
                        {
                            ownedPlayerNumber = stateColor.GetPlayerNumberWithColor(oldClickedButton.BackColor),
                            currentColor = oldClickedButton.BackColor,
                            buttonNumber = int.Parse(oldClickedButton.Name)
                        };

                        selectedButtonInformations.Push(saverButton);

                        oldClickedButton.BackColor = Color.Black;
                    }
                    else MessageBox.Show("You can only select adjacent areas!");

                else MessageBox.Show("You can not select from another state!");

            else MessageBox.Show("You can not select your state!");

        }

        public Stack<ButtonInformationSaver> GetSelectedAreas()
        {
            return selectedButtonInformations;
        }


        private bool IsSelectorPlayerState(Button oldClickedButton, int selectorPlayerNumber)
        {
            return oldClickedButton.BackColor == stateColor.GetColor(selectorPlayerNumber);
        }

        private bool IsStateOfAnotherEnemyPlayer(Button oldClickedButton)
        {
            return !StackIsEmpty() && oldClickedButton.BackColor != selectedButtonInformations.First().currentColor;
        }
        
        private bool IsAreaAdjacent(Button currentArea, int stateNumber)
        {
            if (StackIsEmpty())
                return stateAreas.IsAdjacentToTheAreas(currentArea, stateAreas.GetStateEndZones(stateNumber));

            else
            {
                List<Button> selectedAreas = new List<Button>();

                foreach (var currentSelectedAreaInformation in selectedButtonInformations)
                {
                    selectedAreas.Add(currentButtons[currentSelectedAreaInformation.buttonNumber]);
                }

                return stateAreas.IsAdjacentToTheSelectedAreas(currentArea,selectedAreas);
            }
            
        }

        
        

        public void ResetSelections()
        {
            while (selectedButtonInformations.Count != 0)
            {
                ButtonInformationSaver oldButtonProperties = selectedButtonInformations.Pop();
                currentButtons[oldButtonProperties.buttonNumber].BackColor = oldButtonProperties.currentColor;
            }
        }
    }
}
