using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public static class WarningMessager
    {
        public static string warningMessage;

        public static void AlreadySelected()
        {
            warningMessage = "You already selected the area!";
        }
        
        public static void SelectorPlayerState()
        {
            warningMessage = "You can not select your state!";
        }

        public static void StateOfEnemyPlayer()
        {
            warningMessage = "You can not select from another state!";
        }

        public static void AreaNotAdjacent()
        {
            warningMessage = "You can only select adjacent areas!";
        }

        public static void NotSelectorPlayerState()
        {
            warningMessage = "You have to select your state!";
        }
        
        public static void AreasNotEquals()
        {
            warningMessage = "Enemy and your count of selected areas are not equals!";
        }
    }
}
