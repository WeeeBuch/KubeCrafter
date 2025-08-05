namespace KubeCrafter.Core;

public class Ingredient
{
    public string Name { get; set; }
    public string Mod { get; set; }
    public IngredientType Type { get; set; }
    public Number Count { get; set; }

    public string ToKubeJS()
    {
        return $"";
    }

    public string ToJSON()
    {
        return $"";
    }

}
