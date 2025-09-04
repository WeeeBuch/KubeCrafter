using System;
using System.ComponentModel;
using KubeCrafter.Core;
using KubeCrafter.Core.Base.Ingredient;

namespace KubeCrafter.Core.Base.Ingredient;

public class Ingredient : IEditableObject
{
    private Ingredient _backup;
    private bool _inEdit;

    public string Name { get; set; }
    public string Mod { get; set; }
    public IngredientType Type { get; set; }
    public Number Count { get; set; }
    public int FotmatVersion = 0;

    public override string ToString()
    {
        return $"{Type}: {Mod}:{Name} x{Count}";
    }

    public void BeginEdit()
    {
        if (_inEdit) return;

        _backup = DeepCopy();
        _inEdit = true;
    }

    public void CancelEdit()
    {
        if (!_inEdit) return;

        Name = _backup.Name;
        Mod = _backup.Mod;
        Type = _backup.Type;
        Count = _backup.Count.DeepCopy();
        FotmatVersion = _backup.FotmatVersion;

        _inEdit = false;
    }

    public void EndEdit()
    {
        _backup = null;
        _inEdit = false;
    }

    private Ingredient DeepCopy()
    {
        return new Ingredient
        {
            Name = this.Name,
            Mod = this.Mod,
            Type = this.Type,
            Count = this.Count?.DeepCopy(),
            FotmatVersion = this.FotmatVersion
        };
    }
}
