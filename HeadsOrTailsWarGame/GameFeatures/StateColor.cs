using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public class StateColor
    {
        public Color GetColor(int colorNumber)
        {
            if (colorNumber < 3) return GetColorUpperRegion(colorNumber);
            else return GetColorLowerRegion(colorNumber - 3);
        }

        private Color GetColorUpperRegion(int colorNumber)
        {
            switch (colorNumber)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Blue;
                default:
                    return Color.Yellow;

            }
        }

        private Color GetColorLowerRegion(int colorNumber)
        {
            switch (colorNumber)
            {
                case 0:
                    return Color.Purple;
                case 1:
                    return Color.Green;
                default:
                    return Color.Orange;

            }
        }

        public int GetPlayerNumberWithColor(Color color)
        {
            int currentPlayerNumber = 0;

            while(GetColor(currentPlayerNumber)!= color)
            { 
                currentPlayerNumber++;
            }

            return currentPlayerNumber;
        }
    }
}
