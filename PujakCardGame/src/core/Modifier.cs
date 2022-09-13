namespace PujakCardGame;

public abstract class Modifier // : IObserver
{
    public string Name { get; protected set; }
    public AbstractCard Card { get; protected set; }

}