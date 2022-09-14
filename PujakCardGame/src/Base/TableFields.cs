using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujakCardGame;

public class Field : IEnumerable<Card>
{
    private readonly List<Card> _cards;

    public int MaxSize { get; set; }

    /// <summary>
    /// Tries to place card on  hero's field 
    /// </summary>
    /// <returns>true when placement succeed, else false</returns>
    public bool TryPlaceCard(Card card, Hero fieldOwner)
    {
        throw new NotImplementedException();
    }

    /// <returns>true when removed; false if card not found</returns>
    public bool RemoveCard(Card card, Hero fieldOwner)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_cards).GetEnumerator();
}

