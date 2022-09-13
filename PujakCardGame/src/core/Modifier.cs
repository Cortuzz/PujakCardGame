namespace PujakCardGame;

public abstract class Modifier: IObserver
{
    public string Name { get; protected set; }
    public AbstractCard Card { get; protected set; }

    public abstract void Update(IObservable observable, EventType et);
}