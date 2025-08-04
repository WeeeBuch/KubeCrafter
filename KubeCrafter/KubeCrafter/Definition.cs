using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core
{
    public class Definition
    {
        public string Type { get; set; }
        public string[] Fields { get; set; }
        public Dictionary<string, List<string>> Output { get; set; }




    }
}
