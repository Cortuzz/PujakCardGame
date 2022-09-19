using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Linq;

namespace PujakCardGame
{
    public class CardsDirector
    {
        private CardsDirector() { }

        public static CardsDirector Instance = new CardsDirector();

        private readonly Dictionary<string, CardBuilder> _builders = new();


        public Card ConstructCard(string name)
        {
            return _builders[name].Build();
            /*if (!_builders.TryGetValue(name, out CardBuilder builder))
            {
                builder = _configureBuilderFor(name);
                _builders.Add(name, builder);
            }
            return builder.Build();*/
        }

        private void _configureBuilderFor(CardBuilder builder, SimpleCardScema scema, string[] namespaces)
        {
            builder.Mana = scema.Mana;
            builder.Name = scema.Name;
            builder.ModifiersCreator = new ModifiersCreator(scema.Modifiers, namespaces);
        }

        private void _configureBuilderFor(UnitCardBuilder builder, UnitCardScema scema, string[] namespaces)
        {
            _configureBuilderFor((CardBuilder)builder, scema, namespaces);
            builder.Health = scema.Health;
            builder.Damage = scema.Damage;
        }

        public void ProcessScema(CardsScema scema)
        {
            if (scema.SpellCards != null)
            {
                foreach (var cardScema in scema.SpellCards)
                {
                    var builder = new SpellCardBuilder();
                    _configureBuilderFor(builder, cardScema, scema.UsingNamespaces);
                    _builders.Add(cardScema.Name, builder);
                }
            }

            if (scema.UnitCards != null)
            {
                foreach (var cardScema in scema.UnitCards)
                {
                    var builder = new UnitCardBuilder();
                    _configureBuilderFor(builder, cardScema, scema.UsingNamespaces);
                    _builders.Add(cardScema.Name, builder);
                }
            }
        }
    }
}
