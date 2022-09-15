using System;
using System.Collections.Generic;

namespace PujakCardGame;

public class UnitCard : Card, IDamageable
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

    public Damage Damage { get; set; }

    public UnitCard(string name, Hero owner) : base(name, owner) { }
    
    public override bool PlayCard(GameTable table, Hero hero, ITargetable target)
    {
        // todo
        return base.PlayCard(table, hero, target);
    }
    
    public void Attack(IDamageable target)
    {
        var request = new DamageRequest(Damage, this, target, _owner);
        foreach (var mod in GetModifiers());
    }

    public Damage GetAttacked(DamageRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary> TEventArgs -> int  -- delta health </summary>
    public event EventHandler<int> HealthChanged;

    public event EventHandler<DamageRequest> Damaged;
}