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

    public override string ToString()
    {
        decimal number = Before + (After / (decimal)Math.Pow(10, After.ToString().Length));
        return number.ToString("0.##");
    }


    public void AddSmall(int value)
    {
        After += value;
        if (After >= 100)
        {
            Before += After / 100;
            After %= 100;
        }
    }

    public void AddLarge(int value)
    {
        Before += value;
        if (Before < 0) Before = 0;
    }

    public void SubtractSmall(int value)
    {
        After -= value;
        if (After < 0)
        {
            Before -= 1 + (-After / 100);
            After = (After + 100) % 100;
        }
    }

    public void SubtractLarge(int value)
    {
        Before -= value;
        if (Before < 0) Before = 0;
    }
}
