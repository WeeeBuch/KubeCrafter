using KubeCrafter.Core.Base.Recipe;
using KubeCrafter.Core.Base.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core
{
    public class Recipe
    {
        public List<Setting> Settings { get; set; }
        public Definition Def { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public string ToFile()
        {
            return "";
        }

        public string ToKubeJs()
        {
            return "";
        }

        public string ToJson() 
        {
            return "";
        }
    }
}
