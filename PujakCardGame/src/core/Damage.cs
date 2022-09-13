namespace PujakCardGame
{
    public enum DamageType
    {
        Pure,
        Phisical,
        Magic
    }

    public class Damage
    {
        public int amount;
        public DamageType type;

        public Damage(int amount, DamageType type)
        {
            this.amount = amount;
            this.type = type;
        }
    }

    public delegate void DamageEvent(Damage damage, Hero instigator, AbstractCard causer);
}
