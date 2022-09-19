    using System;
using System.Collections;
using System.Collections.Generic;

namespace PujakCardGame;

public class Field : IEnumerable<UnitCard>
{
    private readonly List<UnitCard> _cards = new();

    public int MaxSize { get; set; }
    public int Count => _cards.Count;

    /// <summary>
    /// Tries to place card on  hero's field 
    /// </summary>
    /// <returns>true when placement succeed, else false</returns>
    public bool TryPlaceCard(UnitCard card)
    {
        if (card == null || MaxSize <= _cards.Count) return false;
        _cards.Add(card);
        CardPlaced?.Invoke(this, card);
        return true;
    }

    /// <returns>true when removed; false if card not found</returns>
    public bool RemoveCard(UnitCard card)
    {
        if (!_cards.Remove(card)) return false;
        CardRemoved?.Invoke(this, card);
        return true;
    }

    public IEnumerator<UnitCard> GetEnumerator() => _cards.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_cards).GetEnumerator();

    public event EventHandler<UnitCard> CardPlaced;
    public event EventHandler<UnitCard> CardRemoved;
}

