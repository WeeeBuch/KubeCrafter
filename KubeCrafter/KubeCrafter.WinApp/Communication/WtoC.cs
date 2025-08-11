using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.WinApp.Communication
{
    /// <summary>
    /// Here are the methods that will be used to cummunicate with the CORE.
    /// This is the WPF to CORE communication class.
    /// </summary>
    public static partial class Comms
    {
        public static void RecipeChanged(string recipeName)
        {
            if (recipeName == null) throw new ArgumentNullException(nameof(recipeName), "Recipe name cannot be null.");

            // Here will be calling the CORE to update the recipe.
        }

        public static void ChangeOutputFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException(nameof(format), "Format cannot be null or empty.");
            }

            // Here will be calling the CORE to change the output format.
        }
    }
}
