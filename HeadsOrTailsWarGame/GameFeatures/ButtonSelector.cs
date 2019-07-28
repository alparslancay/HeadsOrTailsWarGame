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

        Button[] currentButtons;

        public ButtonSelector(Button [] stateButtons)
        {
            currentButtons = stateButtons;
        }

        private bool StackIsEmpty()
        {
            return selectedButtonInformations.Count == 0;
        }

        public void SelectButton(Button oldClickedButton)
        {
            if (!StackIsEmpty() && oldClickedButton.BackColor != selectedButtonInformations.First().currentColor) MessageBox.Show("You can not select from another state!");

             else
             {
                 ButtonInformationSaver saverButton = new ButtonInformationSaver()
                 {
                     currentColor = oldClickedButton.BackColor,
                     buttonNumber = int.Parse(oldClickedButton.Name)
                 };
                 selectedButtonInformations.Push(saverButton);

                 oldClickedButton.BackColor = Color.Black;
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
