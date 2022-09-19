using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PujakCardGame;

namespace PujakCardGame
{
    public abstract class CardBuilder
    {
        public string Name { set; protected get; }
        public int Mana { set; private get; }
        public IEnumerator<IModifier> ModifiersCreator { set; private get; }

        protected abstract Card createCard();

        public virtual Card Build()
        {
            var product = createCard();
            product.Mana = Mana;
            ModifiersCreator.Reset();
            while (ModifiersCreator.MoveNext())
                product.AddModifier(ModifiersCreator.Current);
            return product;
        }
    }

    public sealed class SpellCardBuilder : CardBuilder
    {
        protected override Card createCard() => new SpellCard(Name);

        public override SpellCard Build() => (SpellCard)base.Build();
    }

    public sealed class UnitCardBuilder : CardBuilder
    {
        public int Health { set; private get; }
        public Damage Damage { set; private get; }

        protected override Card createCard() => new UnitCard(Name);

        public override UnitCard Build()
        {
            var product =  (UnitCard)base.Build();
            product.Health = Health;
            product.Damage = Damage;
            return product;
        }
    }
}
