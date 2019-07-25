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
        public Color TakeColor(int colorNumber)
        {
            if (colorNumber < 3) return TakeColorUpperRegion(colorNumber);
            else return TakeColorLowerRegion(colorNumber - 3);
        }

        public Color TakeColorUpperRegion(int colorNumber)
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

        public Color TakeColorLowerRegion(int colorNumber)
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
    }
}
