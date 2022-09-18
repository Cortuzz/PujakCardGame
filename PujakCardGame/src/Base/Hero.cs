using System;
using System.Collections.Generic;
using PujakCardGame.Utils;

namespace PujakCardGame;

public class Hero : IDamageable, ITargetable, IModifiable
{
    public readonly List<Card> Hand = new();
    public GameTable Table { get; set; }

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

    private readonly List<IModifier> _modifiers = new();

    public Damage GetAttacked(DamageRequest request)
    {
        request.Target = this;

        foreach (var mod in GetModifiers().PrioritySortedWhereType<IDamageHandler>())
            mod.Handle(this, request);

        Health -= request.Damage.Amount;
        Damaged?.Invoke(this, request);

        return request.Damage;
    }

    public IEnumerable<IModifier> GetModifiers() => _modifiers;

    public void AddModifier(IModifier modifier)
    {
        _modifiers.Add(modifier);
        modifier.Target = this;
    }

    public void RemoveModifier(IModifier modifier)
    {
        _modifiers.Remove(modifier);
        modifier.Target = null;
    }

    public bool TryTarget(Card targeter)
    {
        var contition = new TargetingTransitionResult(true);

        foreach (var mod in GetModifiers().PrioritySortedWhereType<ITargetingHandler>())
            mod.Handle(targeter, contition);

        return contition.Result;
    }

    public void MakeTurn()
    {
        throw new NotImplementedException();
    }

    public event EventHandler<DamageRequest> Damaged;
    public event EventHandler<int> HealthChanged;
    public event EventHandler TurnBegan;
}