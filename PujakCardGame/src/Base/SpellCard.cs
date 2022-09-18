using System;
using PujakCardGame.Utils;

namespace PujakCardGame
{
    public class SpellCard : Card
    {
        public SpellCard(string name) : base(name) { }

        public override bool Play(GameTable table, Hero hero, ITargetable target)
        {
            Owner = hero;
            if (!target.TryTarget(this)) return false;
            foreach (var mod in GetModifiers().PrioritySortedWhereType<ICastHandler>())
                mod.Handle(this, target);    

            return base.Play(table, hero, target);
        }
    }
}
