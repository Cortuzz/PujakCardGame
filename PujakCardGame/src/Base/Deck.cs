using System;
using PujakCardGame.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PujakCardGame;

public class Deck
{
    private readonly string[] _nameSeq;
    private int _index = 0;

    public int RemainingCount => _nameSeq.Length - _index;

    public Deck(IEnumerable<string> nameSeq) => _nameSeq = nameSeq.ToArray();

    public Card GetNextCard()
    {
        var card = CardsDirector.Instance.ConstructCard(_nameSeq[_index++]);
        if (_index == _nameSeq.Length) Expired?.Invoke(this, EventArgs.Empty);
        return card;
    }

    public void Refresh()
    {
        _nameSeq.Shuffle();
        _index = 0;
    }

    public event EventHandler Expired;
}

