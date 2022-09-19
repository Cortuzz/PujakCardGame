using System;

namespace PujakCardGame
{
    public enum DamageType
    {
        Pure,
        Physical,
        Magic
    }

    public readonly record struct Damage(int Amount, DamageType Type);
#nullable enable
    public record DamageRequest(Damage Damage , Card? Causer = null, IDamageable? Target = null, Hero? Instigator = null)
    {
        public Damage Damage = Damage;
        public Card? Causer = Causer;
        public IDamageable? Target = Target;
        public Hero? Instigator = Instigator;
    };
#nullable disable

    public interface IDamageable
    {
        public int Health { get; set; }
        
        /// <returns> Recieved damage </returns>
        public Damage GetAttacked(DamageRequest request);

        /// <summary>
        /// 'e' argument represents processed taken <see cref="DamageRequest"/>
        /// </summary>
        public event EventHandler<DamageRequest> Damaged;

        /// <summary> TEventArgs -> int  -- delta health </summary>
        public event EventHandler<int> HealthChanged;
    }
}
