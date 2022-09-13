namespace PujakCardGame;

public abstract class Modifier
{
    public string Name { get; set; }
    public abstract Card Card { get; set; }
}