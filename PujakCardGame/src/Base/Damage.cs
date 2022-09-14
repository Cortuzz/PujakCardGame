namespace PujakCardGame
{
    public enum DamageType
    {
        Pure,
        Physical,
        Magic
    }

    public record Damage(int Amount, DamageType DamageType);

    public delegate void DamageEvent(Damage damage, Hero instigator, Card causer);
}
