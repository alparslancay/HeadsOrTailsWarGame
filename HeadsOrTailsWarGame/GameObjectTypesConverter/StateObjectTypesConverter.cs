using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjectTypes
{
    public static class StateObjectTypesConverter
    {
        public static Color ConvertStateFlagObjectType(object convertingObject)
        {
            return (Color)convertingObject;
        }
    }
}
