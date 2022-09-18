using System;
using System.Linq;
using System.Collections.Generic;

namespace PujakCardGame;

public class GameTable
{
    private readonly Dictionary<Hero, Field> _charactersFields = new();
    private int _curCharacterIndex;

    public IEnumerable<Hero> Characters => _charactersFields.Keys;

    public void AddCharacter(Hero character, int initialFieldSize)
    {
        character.Table = this;
        _charactersFields.Add(character, new Field() { MaxSize = initialFieldSize });
    }

    public bool PlayCard(Card card, Hero caster, ITargetable target)
    {
        if (!card.Play(this, caster, target)) return false;
        CardPlayed?.Invoke(this, card);
        return true;
    }

    public Field GetHerosField(Hero owner) => _charactersFields[owner];

    public void NextTurn()
    {
        var characters = _charactersFields.Keys;
        System.Diagnostics.Debug.Assert(characters.Count > 0, "Count of characters in table was less than 1");
        _curCharacterIndex = ++_curCharacterIndex % characters.Count;
        characters.ElementAt(_curCharacterIndex).MakeTurn();
    }

    public event EventHandler<Card> CardPlayed;
}