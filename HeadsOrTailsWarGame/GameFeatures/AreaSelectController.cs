using GameObjectTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFeatures
{
    public class AreaSelectController
    {
        public bool IsAlreadySelected(object selectedObject, Color selectColor)
        {
            if (MapObjectTypesConverter.ConvertMapAreaObjectType(selectedObject).BackColor != selectColor)
                return true;

            else
            {
                WarningMessager.AlreadySelected();
                return false;
            }
        }
    }
}
