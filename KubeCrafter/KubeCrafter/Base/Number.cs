namespace KubeCrafter.Core;

public class Number
{
    public int Before { get; set; }
    public int After { get; set; }

    public Number(int before, int after)
    {
        Before = before;
        After = after;
    }

    public override string ToString() => $"{Before}.{After}";


}
