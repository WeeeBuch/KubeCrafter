using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core.Dynamic_Fromating
{
    public class TextLine : IOutputLine
    {
        public string Value { get; set; }
    }

    public class RepeatBlock : IOutputLine
    {
        public string Type { get; set; }
        public string Var { get; set; }
        public string Key { get; set; }
        public string Format { get; set; }
    }
}
