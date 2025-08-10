namespace KubeCrafter.Core.Base.Ingredient;

public class Ingredient
{
    public string Name { get; set; }
    public string Mod { get; set; }
    public IngredientType Type { get; set; }
    public Number Count { get; set; }

    public int FotmatVersion = 0;

    public override string ToString()
    {
        

        return default;
    }
}
