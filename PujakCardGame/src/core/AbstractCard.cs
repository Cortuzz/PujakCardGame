using System.Collections.Generic;
using System;

namespace PujakCardGame;

public abstract class AbstractCard: IModifiable // , IObservable
{
    public ICollection<Modifier> Modifiers => _modifiers;
    public int Mana { get; set; }
    public readonly string Name;

    private List<Modifier> _modifiers;

    public AbstractCard(string name)
    {
        Name = name;
    }

    public abstract bool PlayCard(GameTable table, Hero hero, ITargetable target);

    /// <summary> TEventArgs -> Hero -- hero plays that card</summary>
    event EventHandler<Hero> CardPlayed;

    /// <summary> TEventArgs -> int  -- delta mana </summary>
    event EventHandler<int> ManaChanged;
}