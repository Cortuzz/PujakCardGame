using System;
using PujakCardGame.Utils;


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

    public UnitCard(string name) : base(name) { }
    
    public override bool PlayCard(GameTable table, Hero hero, ITargetable target)
    {
        // Unit cards must be placed on table, not executed on target
        if (target != null) return false;
        // Placing card on table could be not successful
        if (!table.GetHerosField(hero).TryPlaceCard(this)) return false; 

        return base.PlayCard(table, hero, target);
    }
    
    public void Attack(IDamageable target)
    {
        var request = new DamageRequest(Damage, this, target, Owner);
        foreach (var mod in GetModifiers().PrioritySortedWhereType<IAttackHandler>())
            mod.Handle(this, request);

        Attacked?.Invoke(this, request with
        {
            Damage = target.GetAttacked(request)
        });
    }

    public Damage GetAttacked(DamageRequest request)
    {
        request.Target = this;
        foreach (var mod in GetModifiers().PrioritySortedWhereType<IDamageHandler>())
            mod.Handle(this, request);

        Health -= request.Damage.Amount;
        Damaged?.Invoke(this, request);
        return request.Damage;
    }

    public event EventHandler<int> HealthChanged;

    public event EventHandler<DamageRequest> Damaged;

    /// <summary>
    /// 'e' argument represents processed dealt <see cref="DamageRequest"/>
    /// </summary>
    public event EventHandler<DamageRequest> Attacked;
}