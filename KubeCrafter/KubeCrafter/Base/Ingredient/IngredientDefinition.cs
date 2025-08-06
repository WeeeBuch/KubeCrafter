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

        private readonly List<string> PlaceHolders = ["mod", "name", "count"];

        public string Render(Ingredient ingredient)
        {
            if (Types == null) throw new ArgumentNullException("Supported types are null.");

            string selectedType = ingredient.Type.ToString();

        }
    }
}
