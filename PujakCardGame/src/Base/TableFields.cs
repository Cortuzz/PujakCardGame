using System.Collections;
using System.Collections.Generic;

namespace PujakCardGame;

public class Field : IEnumerable<Card>
{
    private readonly List<Card> _cards;

    public int MaxSize { get; set; }
    public int Count => _cards.Count;

    /// <summary>
    /// Tries to place card on  hero's field 
    /// </summary>
    /// <returns>true when placement succeed, else false</returns>
    public bool TryPlaceCard(Card card)
    {
        if (MaxSize <= _cards.Count) return false;
        _cards.Add(card);
        return true;
    }

    /// <returns>true when removed; false if card not found</returns>
    public bool RemoveCard(Card card) => _cards.Remove(card);

    public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_cards).GetEnumerator();
}

