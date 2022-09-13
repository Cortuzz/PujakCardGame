namespace PujakCardGame;

/// <summary>
/// Deprecated
/// </summary>
public interface IObserver
{
    public void Update(IObservable observable, EventType et);
}