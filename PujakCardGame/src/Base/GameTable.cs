using System;

namespace PujakCardGame;

public class GameTable
{
    public readonly Hero Enemy;
    public readonly Hero Charecter;

    public GameTable(Hero charecter, Hero enemy)
    {
        Charecter = charecter;
        Enemy = enemy;
    }

    // + GetHeroCards(Hero) : List<AbstractCard>

    public bool PlayCard(Card card, Hero caster, ITargetable target)
    {
        throw new NotImplementedException();
    }

    public Field GetHerosField(Hero owner)
    {
        throw new NotImplementedException();
    }
}