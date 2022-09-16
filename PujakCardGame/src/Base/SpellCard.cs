using System;
using PujakCardGame.Utils;

namespace PujakCardGame
{
    public class SpellCard : Card
    {
        public SpellCard(string name) : base(name) { }

        public override bool PlayCard(GameTable table, Hero hero, ITargetable target)
        {
            Owner = hero;
            if (!target.TryTarget(this)) return false;
            foreach (var mod in GetModifiers().PrioritySortedWhereType<ICastHandler>())
                mod.Handle(this, target);    

            return base.PlayCard(table, hero, target);
        }
    }
}
