using System;

namespace PujakCardGame
{
    public enum DamageType
    {
        Pure,
        Physical,
        Magic
    }

    public readonly record struct Damage(int Amount, DamageType DamageType);
#nullable enable
    public record DamageRequest(Damage Damage, Card? Causer = null, IDamageable? Target = null, Hero? Instigator = null);
#nullable disable

    public interface IDamageable
    {
        public int Health { get; set; }
        
        /// <returns> Recieved damage </returns>
        public Damage GetAttacked(DamageRequest request);

        /// <summary>
        /// 'e' argument represents processed <see cref="DamageRequest"/>
        /// </summary>
        public event EventHandler<DamageRequest> Damaged;
    }
}
