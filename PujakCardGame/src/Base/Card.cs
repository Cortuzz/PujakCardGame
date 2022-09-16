using PujakCardGame.Utils;
using System;
using System.Collections.Generic;

namespace PujakCardGame;

public abstract class Card : IModifiable, ITargetable
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
    public virtual Hero Owner { get; protected set; }

    private readonly List<IModifier> _modifiers;

    public Card(string name) => Name = name;

    public virtual bool PlayCard(GameTable table, Hero hero, ITargetable? target)
    {
        Owner = hero;
        CardPlayed?.Invoke(this, hero);
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
        _modifiers.Remove(modifier);
        modifier.Target = null;
    }

    public bool TryTarget(Card targeter)
    {
        var contition = new TargetingTransitionResult(true);
        foreach (var mod in _modifiers.PrioritySortedWhereType<ITargetingHandler>())
            mod.Handle(targeter, contition);

        return contition.Result;
    }

    /// <summary> TEventArgs -> Hero -- hero plays that card</summary>
    public event EventHandler<Hero> CardPlayed;

    /// <summary> TEventArgs -> int  -- delta mana </summary>
    public event EventHandler<int> ManaChanged;
}