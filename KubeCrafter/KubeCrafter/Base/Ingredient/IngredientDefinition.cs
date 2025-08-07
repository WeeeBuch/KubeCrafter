using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core.Base.Ingredient
{
    public class IngredientDefinition
    {
        public List<string> Types { get; set; }
        public Dictionary<string, Dictionary<string, List<string>>> Outputs { get; set; }

        public List<string> Render(Ingredient ingredient)
        {
            if (Types == null) throw new ArgumentNullException("Supported types are null.");

            Dictionary<string, string> placeHolderValues = new()
            {
                {"mod", ingredient.Mod},
                {"name", ingredient.Name},
                {"count", ingredient.Count.ToString()}
            };

            string selectedType = Types.Contains(ingredient.Type.ToString()) ? ingredient.Type.ToString() : throw new Exception("Unsupported ingredient type.");
        
            List<string> rawFormat = Outputs[Global.SelectedOutputFormat][selectedType];
        
            return DynamicFormater.Format(rawFormat, placeHolderValues);
        }

        public int GetPossipleFormatsCount(Ingredient i) => Outputs[Global.SelectedOutputFormat][i.Type.ToString()].Count;
    }
}
