using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameObjectTypes
{
    public static class MapObjectTypesConverter
    {
        public static Button ConvertMapAreaObjectType(object convertingObject)
        {
            return (Button)convertingObject;
        }
    }
}
