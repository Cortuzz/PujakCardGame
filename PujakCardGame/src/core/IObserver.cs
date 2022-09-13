namespace PujakCardGame;

public interface IObserver
{
    public void Update(IObservable observable, EventType et);
}