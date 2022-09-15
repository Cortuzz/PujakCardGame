using System.Collections.Generic;
using System;

namespace PujakCardGame;

public abstract class Card : IModifiable
{
    private int _mana;
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

    public readonly string Name;
    protected readonly Hero _owner;

    private List<IModifier> _modifiers;

    public Card(string name, Hero owner)
    {
        Name = name;
        _owner = owner;
    }

    public virtual bool PlayCard(GameTable table, Hero hero, ITargetable target)
    {
        CardPlayed!.Invoke(this, hero);
        return true;
    }

    public IEnumerable<IModifier> GetModifiers() => _modifiers;

    public void AddModifier(IModifier modifier)
    {
        _modifiers.Add(modifier);
        modifier.Target = this;
    }

    public void RemoveModifier(IModifier modifier)
    {
        _modifiers.Add(modifier);
        modifier.Target = null;
    }

    /// <summary> TEventArgs -> Hero -- hero plays that card</summary>
    public event EventHandler<Hero> CardPlayed;

    /// <summary> TEventArgs -> int  -- delta mana </summary>
    public event EventHandler<int> ManaChanged;
}