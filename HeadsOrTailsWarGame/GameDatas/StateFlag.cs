using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public static class StateFlag
    {
        public static Color GetFlag(int flagNumber)
        {
            if (flagNumber < 3) return GetFlagUpperRegion(flagNumber);
            else return GetFlagLowerRegion(flagNumber - 3);
        }

        private static Color GetFlagUpperRegion(int flagNumber)
        {
            switch (flagNumber)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Blue;
                default:
                    return Color.Yellow;

            }
        }

        private static Color GetFlagLowerRegion(int flagNumber)
        {
            switch (flagNumber)
            {
                case 0:
                    return Color.Purple;
                case 1:
                    return Color.Green;
                default:
                    return Color.Orange;

            }
        }

        public static int GetPlayerNumberWithFlag(object flag)
        {
            int currentPlayerNumber = 0;

            while(GetFlag(currentPlayerNumber)!= (Color)flag)
            { 
                currentPlayerNumber++;
            }

            return currentPlayerNumber;
        }
    }
}
