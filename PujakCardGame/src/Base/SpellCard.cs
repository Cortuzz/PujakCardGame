using System;

namespace PujakCardGame
{
    public class SpellCard : Card
    {
        public SpellCard(string name) : base(name) { }

        public override bool PlayCard(GameTable table, Hero hero, ITargetable target)
        {
            // todo
            return base.PlayCard(table, hero, target);
        }
    }
}
