using System.Collections.Generic;
using System;

namespace PujakCardGame;

public abstract class Card : IModifiable // , IObservable
{
    public ICollection<Modifier> Modifiers => _modifiers;

    public int Mana
    {
        get => _mana;
        set
        {
            if (_mana == value) 
                return;
            var d = value - _mana;
            _mana = value;
            ManaChanged?.Invoke(this, d);
        }
    }

    private int _mana;

    public readonly string Name;

    private List<Modifier> _modifiers;

    public Card(string name)
    {
        Name = name;
    }

    public virtual bool PlayCard(GameTable table, Hero hero, ITargetable target)
    {
        CardPlayed!.Invoke(this, hero);
        return true;
    }

    /// <summary> TEventArgs -> Hero -- hero plays that card</summary>
    public event EventHandler<Hero> CardPlayed;

    /// <summary> TEventArgs -> int  -- delta mana </summary>
    public event EventHandler<int> ManaChanged;
}