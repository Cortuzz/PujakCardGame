namespace PujakCardGame;

#nullable enable
public record ModifierScema(string Name, double[]? Args);

public record SimpleCardScema(string Name, int Mana, ModifierScema[] Modifiers);

public record UnitCardScema : SimpleCardScema
{
    public int Health { get; init; }
    public Damage Damage { get; init; }

    public UnitCardScema(string name, int mana, int health, Damage damage, ModifierScema[] modifiers)
        : base(name, mana, modifiers)
    {
        Health = health;
        Damage = damage;
    }
}

public record CardsScema(string[] UsingNamespaces, UnitCardScema[]? UnitCards, SimpleCardScema[]? SpellCards);
#nullable disable