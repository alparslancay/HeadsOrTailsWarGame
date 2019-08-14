using GameEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDatas
{
    public class StateAreasDatas
    {
        private static StateAreasDatas singletonStateAreas;
        private GameState[] gameStates;
        private Button[] mapAreas;

        private StateAreasDatas()
        {
        }

        public static StateAreasDatas GetStateAreasClass()
        {
            if (singletonStateAreas == null)
                singletonStateAreas = new StateAreasDatas();

            return singletonStateAreas;

        }

        public void CreateStateAreas(Button[] mapAreas , GameState[] gameStates)
        {
            this.gameStates = gameStates;
            this.mapAreas = mapAreas;
        }

        public Button[] GetStateAreas(int stateNumber)
        {
            Button[] areasOfState = new Button[gameStates[stateNumber].ownedAreas.Count];

            for (int areaRecorder = 0; areaRecorder < gameStates[stateNumber].ownedAreas.Count; areaRecorder++)
            {
                areasOfState[areaRecorder] = mapAreas[(int)gameStates[stateNumber].ownedAreas[areaRecorder]];
            }

            return areasOfState;
        } 

        public List<Button> GetStateEndZones(int stateNumber)
        {
            Button[] areasOfState = GetStateAreas(stateNumber);
            List<Button> stateEndZones = new List<Button>();

            foreach (var currentArea in areasOfState)
            {
                if (IsThereDifferentStateAround(currentArea))
                    stateEndZones.Add(currentArea);
            }

            return stateEndZones;
        }

        public bool IsAdjacentAreas(Button firstArea, Button secondArea)
        {
            int adjacentValue = Math.Abs(int.Parse(firstArea.Name) - int.Parse(secondArea.Name));
            return adjacentValue == 1 || adjacentValue == 30;
        }

        public bool IsAdjacentToTheAreas(Button singularArea, List<Button> pluralAreas)
        {
            foreach (var currentArea in pluralAreas)
            {
                if (IsAdjacentAreas(singularArea, currentArea))
                    return true;
            }

            return false;
        }


        public bool IsAdjacentToTheSelectedAreas(Button desiredArea, List<Button> selectedAreas)
        {
            List<Button> adjacentsCurrentArea = GetAdjacentsOfArea(desiredArea);

            foreach (var currentSelectedArea in selectedAreas)
            {
                foreach (var currentAdjacentsArea in adjacentsCurrentArea)
                {
                    if (currentSelectedArea.Equals(currentAdjacentsArea))
                        return true;
                }
            }

            return false;
        }

        private bool IsThereDifferentStateAround(Button currentButton)
        {
            foreach (var currentAdjacentArea in GetAdjacentsOfArea(currentButton))
            {
                if (currentButton.BackColor != currentAdjacentArea.BackColor)
                    return true;
            }

            return false;
        }

        private List<Button> GetAdjacentsOfArea(Button selectedArea)
        {
            List<Button> areasToCompare = new List<Button>();

            if (!IsMapVerticalEndLeftZone(selectedArea))
                areasToCompare.Add(mapAreas[int.Parse(selectedArea.Name) - 1]);

            if (!IsMapVerticalEndRightZone(selectedArea))
                areasToCompare.Add(mapAreas[int.Parse(selectedArea.Name) + 1]);

            if(!IsMapHorizontalEndDownZone(selectedArea))
                areasToCompare.Add(mapAreas[int.Parse(selectedArea.Name) + 30]);

            if (!IsMapHorizontalEndUpZone(selectedArea))
                areasToCompare.Add(mapAreas[int.Parse(selectedArea.Name) - 30]);

            return areasToCompare;

        }
        
        private bool IsMapVerticalEndRightZone(Button selectedArea)
        {
            int areaNumber = int.Parse(selectedArea.Name);
            return areaNumber % 30 == 29;
        }

        private bool IsMapVerticalEndLeftZone(Button selectedArea)
        {
            int areaNumber = int.Parse(selectedArea.Name);
            return areaNumber % 30 == 0;
        }

        private bool IsMapHorizontalEndUpZone(Button selectedArea)
        {
            int areaNumber = int.Parse(selectedArea.Name);
            return areaNumber < 30;

        }

        private bool IsMapHorizontalEndDownZone(Button selectedArea)
        {
            int areaNumber = int.Parse(selectedArea.Name);
            return areaNumber > 869;
        }
    }
}
