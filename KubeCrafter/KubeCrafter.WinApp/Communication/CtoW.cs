using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.WinApp.Communication
{
    public static partial class Comms
    {
        public static List<string> GetRecipeNames()
        {
            // This method will be used to get the recipe names from the CORE.

            return ["Default"];
        }

        public static List<string> GetRecipeFormats(string recipeName)
        {
            if (string.IsNullOrEmpty(recipeName))
            {
                throw new ArgumentNullException(nameof(recipeName), "Recipe name cannot be null or empty.");
            }
            // This method will be used to get the recipe formats from the CORE.

            return new List<string> { "Format1", "Format2", "Format3" };
        }
    }
}
