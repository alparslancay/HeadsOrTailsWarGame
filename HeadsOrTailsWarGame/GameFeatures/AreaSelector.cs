using GameDatas;
using GameEntities;
using GameObjectTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFeatures
{
    public class AreaSelector
    {
        Stack<AreaSelectNode> selectedTakeOverAreaNodes = new Stack<AreaSelectNode>();
        Stack<AreaSelectNode> selectorBetAreaNodes = new Stack<AreaSelectNode>();
        StateAreasDatas stateAreas = StateAreasDatas.GetStateAreasClass();

        Button[] currentAreas;

        public AreaSelector(Button [] gameAreas)
        {
            currentAreas = gameAreas;
        }

        private bool StackIsEmpty()
        {
            return selectedTakeOverAreaNodes.Count == 0;
        }
        
        public void SelectOtherStateArea(Button selectedArea, int selectorPlayerNumber)
        {
            if (!IsSelectorPlayerState(selectedArea, selectorPlayerNumber))

                if (!IsStateOfAnotherEnemyPlayer(selectedArea))

                    if (IsAreaAdjacent(selectedArea, selectorPlayerNumber, selectedTakeOverAreaNodes))
                    {

                        AreaSelectNode areaNode = new AreaSelectNode()
                        {
                            ownedStateNumber = StateFlag.GetPlayerNumberWithFlag(selectedArea.BackColor),
                            currentFlag = selectedArea.BackColor,
                            areaNumber = int.Parse(selectedArea.Name)
                        };

                        selectedTakeOverAreaNodes.Push(areaNode);

                        selectedArea.BackColor = Color.Black;
                    }
                    else MessageBox.Show("You can only select adjacent areas!");

                else MessageBox.Show("You can not select from another state!");

            else MessageBox.Show("You can not select your state!");

        }

        public void SelectSelectorStateArea(Button selectedArea, int selectorPlayerNumber)
        {
            int selectedStateNumber = selectedTakeOverAreaNodes.First().ownedStateNumber;

            if (IsSelectorPlayerState(selectedArea, selectorPlayerNumber))

                if (IsAreaAdjacent(selectedArea, selectedStateNumber, selectorBetAreaNodes))
                {

                    AreaSelectNode saverButton = new AreaSelectNode()
                    {
                        ownedStateNumber = StateFlag.GetPlayerNumberWithFlag(selectedArea.BackColor),
                        currentFlag = selectedArea.BackColor,
                        areaNumber = int.Parse(selectedArea.Name)
                    };

                    selectorBetAreaNodes.Push(saverButton);

                    selectedArea.BackColor = Color.White;
                }
                else MessageBox.Show("You can only select adjacent areas!");

            else MessageBox.Show("You have to select your state!");

        }

        public void RemoveTakeOverArea(Button selectedArea)
        {
            Stack<AreaSelectNode> currentTakeOverAreasInformations = new Stack<AreaSelectNode>();

            foreach (var currentAreaInformations in selectedTakeOverAreaNodes)
            {
                if (currentAreaInformations.areaNumber != int.Parse(selectedArea.Name))
                    currentTakeOverAreasInformations.Push(currentAreaInformations);
            }

            selectedTakeOverAreaNodes = currentTakeOverAreasInformations;
        }

        public void RemoveBetArea(Button selectedArea)
        {
            Stack<AreaSelectNode> currentBetAreasInformations = new Stack<AreaSelectNode>();

            foreach (var currentAreaInformations in selectorBetAreaNodes)
            {
                if (currentAreaInformations.areaNumber != int.Parse(selectedArea.Name))
                    currentBetAreasInformations.Push(currentAreaInformations);
            }

            selectedTakeOverAreaNodes = currentBetAreasInformations;
        }

        public Stack<AreaSelectNode> GetTakeOverAreas()
        {
            return selectedTakeOverAreaNodes;
        }

        public Stack<AreaSelectNode> GetSelectorBetAreas()
        {
            return selectorBetAreaNodes;
        }

        public void ResetSelections()
        {
            while (selectedTakeOverAreaNodes.Count != 0)
            {
                AreaSelectNode oldAreaNode = selectedTakeOverAreaNodes.Pop();
                currentAreas[oldAreaNode.areaNumber].BackColor = StateObjectTypesConverter.ConvertStateFlagObjectType(oldAreaNode.currentFlag);
            }

            while (selectorBetAreaNodes.Count != 0)
            {
                AreaSelectNode oldAreaNode = selectorBetAreaNodes.Pop();
                currentAreas[oldAreaNode.areaNumber].BackColor = StateObjectTypesConverter.ConvertStateFlagObjectType(oldAreaNode.currentFlag);
            }
        }

        public int GetSelectedStateNumber()
        {
            if (selectedTakeOverAreaNodes.Count == 0)
                return -1;
            else
                return selectedTakeOverAreaNodes.First().ownedStateNumber;
        }

        private bool IsSelectorPlayerState(Button selectedArea, int selectorPlayerNumber)
        {
            return selectedArea.BackColor == StateFlag.GetFlag(selectorPlayerNumber);
        }

        private bool IsStateOfAnotherEnemyPlayer(Button selectedArea)
        {
            return !StackIsEmpty() && selectedArea.BackColor != StateObjectTypesConverter.ConvertStateFlagObjectType(selectedTakeOverAreaNodes.First().currentFlag);
        }
        
        private bool IsAreaAdjacent(Button selectedArea, int stateNumber, Stack<AreaSelectNode> selectedAreas)
        {
            if (selectedAreas.Count == 0)
                return stateAreas.IsAdjacentToTheAreas(selectedArea, stateAreas.GetStateEndZones(stateNumber));

            else
            {
                List<Button> selectedAreasList = new List<Button>();

                foreach (var currentSelectedAreaNode in selectedAreas)
                {
                    selectedAreasList.Add(currentAreas[currentSelectedAreaNode.areaNumber]);
                }

                return stateAreas.IsAdjacentToTheSelectedAreas(selectedArea,selectedAreasList);
            }
            
        }
       
    }
}
