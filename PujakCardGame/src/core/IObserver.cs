namespace PujakCardGame;

/// <summary>
/// Depricated
/// </summary>
public interface IObserver
{
    public void Update(IObservable observable, EventType et);
}