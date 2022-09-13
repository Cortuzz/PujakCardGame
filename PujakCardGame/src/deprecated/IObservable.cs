namespace PujakCardGame;

/// <summary>
/// Deprecated
/// </summary>
public interface IObservable
{
    public void Subscribe(IObserver observer);
    public void Unsubscribe(IObserver observer);
    public void Dispatch(EventType eventType);
}
