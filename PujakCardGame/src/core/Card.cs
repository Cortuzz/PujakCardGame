using System.Collections.Generic;

namespace PujakCardGame;

public abstract class Card: IModifiable, IObservable
{
    public ICollection<Modifier> Modifiers { get; }
    public string Name { get; }
    public int Mana { get; }

    private List<IObserver> _observers = new();

    public abstract bool PlayCard(GameTable table, Hero hero, ITargetable target);
    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Dispatch(EventType eventType)
    {
        foreach (var observer in _observers)
        {
            observer.Update(this, eventType);
        }
    }
}