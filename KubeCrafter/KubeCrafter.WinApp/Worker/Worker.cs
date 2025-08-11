using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KubeCrafter.WinApp.Communication;

namespace KubeCrafter.WinApp.Worker
{
    public static partial class Worker
    {
        public static void OnStart(MainWindow window)
        {
            Comms.LoadDefinitions();

            List<string> recipes = Comms.GetRecipeNames();
            window.ItemsList = new ObservableCollection<string>(recipes);
            



        }

        public static void OnRecipeChanged(MainWindow window, string recipeName)
        {
            if (string.IsNullOrEmpty(recipeName))
            {
                throw new ArgumentNullException(nameof(recipeName), "Recipe name cannot be null or empty.");
            }
            
            Comms.RecipeChanged(recipeName);
            
            List<string> formats = Comms.GetRecipeFormats(recipeName);
            window.Formats = new ObservableCollection<string>(formats);


        }

        public static void FormatSelected(MainWindow window, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException(nameof(format), "Format cannot be null or empty.");
            }
            
            Comms.ChangeOutputFormat(format);
        }

        public static void AnyRecipeChange()
        {


        }
    }
}
