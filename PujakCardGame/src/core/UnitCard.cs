using System;

namespace PujakCardGame;

public class UnitCard : AbstractCard
{
    private int _health;
    public int Health 
    { 
        get => _health;
        set
        {
            if (_health == value) return;
            var d = value - _health;
            _health = value;
            HealthChanged?.Invoke(this, d);
        }
    }

    private int _damage;
    public int Damage
    {
        get => _damage;
        set
        {
            if (_damage == value) return;
            var d = value - _damage;
            _damage = value;
            DamageChanged?.Invoke(this, d);
        }
    }


    public UnitCard(string name) : base(name)
    {
    }


    public override bool PlayCard(GameTable table, Hero hero, ITargetable target)
    {
        throw new NotImplementedException();
    }

    public Damage Attack(AbstractCard causer, Hero instigator)
    {
        throw new NotImplementedException();
    }

    /// <summary> TEventArgs -> int  -- delta health </summary>
    event EventHandler<int> HealthChanged;

    /// <summary> TEventArgs -> int  -- delta damage </summary>
    event EventHandler<int> DamageChanged;

    event DamageEvent CardDamaged;
}