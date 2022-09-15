using System;

namespace PujakCardGame;

public class Hero : IDamageable
{
    public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public event EventHandler<DamageRequest> Damaged;

    public Damage GetAttacked(DamageRequest request)
    {
        throw new NotImplementedException();
    }
}