namespace PujakCardGame;

public abstract class Modifier: IObserver
{
    public string Name { get; protected set; }
    public Card Card { get; protected set; }

    public abstract void Update(IObservable observable, EventType et);
}