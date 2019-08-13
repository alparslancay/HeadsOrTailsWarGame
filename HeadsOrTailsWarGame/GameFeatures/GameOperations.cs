using GameDatas;
using GameEntities;
using GameObjectTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public class GameOperations
    {
        WarPlugin warPlugin;
        public GameCreater gameCreater = new GameCreater();
        AreaSelector areaSelector;
        FinishController finishController;
        AreaSelectController selectController = new AreaSelectController();
        LinkedList<int> currentPlayersNumber = new LinkedList<int>();

        int selectorStateNumber;
        int selectingAreaStateNumber;
        int selectedStateNumber;

        public GameOperations(int numberPlayers)
        {
            gameCreater.CreateMap(numberPlayers, GetDefaultStateName(numberPlayers));
            areaSelector = new AreaSelector(gameCreater.GetGameAreas());
            warPlugin = new WarPlugin(gameCreater.GetGameAreas(), gameCreater.gameStates);
            finishController = new FinishController(gameCreater.gameStates);

            for (int playerNumberRecorder = 0; playerNumberRecorder < numberPlayers; playerNumberRecorder++)
                currentPlayersNumber.AddLast(playerNumberRecorder);

            gameCreater.CreateMap(numberPlayers, GetDefaultStateName(numberPlayers));

            selectorStateNumber = 0;
        }

        public bool SelectTheArea(object selectedObject)
        {
            if (selectorStateNumber == selectingAreaStateNumber)
                return SelectorSelectEnemyArea(selectedObject);
            else
                return SelectorSelectOwnArea(selectedObject);
        }

        private bool SelectorSelectOwnArea(object selectedObject)
        {
            if (selectController.IsAlreadySelected(selectedObject, SelectingAreaColor.GetSelectorSelectingOwnAreaColor()))
            {
                areaSelector.SelectSelectorStateArea(MapObjectTypesConverter.ConvertMapAreaObjectType(selectedObject), selectorStateNumber);
                return true;
            }
            else
                return false;
        }

        private bool SelectorSelectEnemyArea(object selectedObject)
        {
            if (selectController.IsAlreadySelected(selectedObject, SelectingAreaColor.GetSelectorSelectingEnemyAreaColor()))
            {
                areaSelector.SelectOtherStateArea(MapObjectTypesConverter.ConvertMapAreaObjectType(selectedObject), selectorStateNumber);
                return true;
            }
            else
                return false;

        }

        public bool TryCaptureAreas()
        {
            selectedStateNumber = areaSelector.GetSelectedStateNumber();

            Stack<AreaSelectNode> requestedAreas = areaSelector.GetTakeOverAreas();
            Stack<AreaSelectNode> betAreas = areaSelector.GetSelectorBetAreas();
            if (requestedAreas.Count != 0 && requestedAreas.Count == betAreas.Count)
            {
                warPlugin.AreaRequest(selectorStateNumber, selectedStateNumber, requestedAreas, betAreas);
                return true;
            }

            else
                return false;
        }


        public string GameStatementControllerMessage()
        {
            if (finishController.IsWinner(selectorStateNumber))

                return "Congratulations! You are winner!";

            else if (finishController.IsLoser(selectorStateNumber))

                return "You are defeat!";

            else
                return SelectedStateStatementControllerMessage(selectedStateNumber);

        }

        private string SelectedStateStatementControllerMessage(int selectedStateNumber)
        {
            if (finishController.IsLoser(selectedStateNumber))
            {
                currentPlayersNumber.Remove(selectedStateNumber);
                return ("You have defeated the" + gameCreater.gameStates[selectedStateNumber].name + "state!");

            }

            else
                return null;
                    
        }

        public void NextTurn()
        {
            areaSelector.ResetSelections();

            LinkedListNode<int> previousStateTurnNode = currentPlayersNumber.Find(selectorStateNumber);

            LinkedListNode<int> currentStateNode = previousStateTurnNode.Next ?? previousStateTurnNode.List.First;
            
            selectorStateNumber = currentStateNode.Value;
        }

        private string[] GetDefaultStateName(int numberPlayers)
        {
            string[] stateNames = new string[numberPlayers];

            for (int stateNameRecorder = 0; stateNameRecorder < stateNames.Length; stateNameRecorder++)
            {
                stateNames[stateNameRecorder] = StateFlag.GetFlag(stateNameRecorder).Name;
            }

            return stateNames;
        }

        public void ResetSelections()
        {
            areaSelector.ResetSelections();
        }

        public void ChangeSelectingAreaStateNumber(bool IsSelectorState)
        {
            if (IsSelectorState)
                selectingAreaStateNumber = selectorStateNumber;
            else
                selectingAreaStateNumber = areaSelector.GetSelectedStateNumber();
        }

        public int GetSelectorNumber()
        {
            return selectorStateNumber;
        }

        public int GetSelectingAreaStateNumber()
        {
            return selectingAreaStateNumber;
        }
    }
}
