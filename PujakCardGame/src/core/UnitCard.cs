namespace PujakCardGame;

public class UnitCard: Card
{
    public int Health => _health;
    public int Damage => _damage;

    private int _health;
    private int _damage;
    
    public override bool PlayCard(GameTable table, Hero hero, ITargetable target)
    {
        Dispatch(EventType.CardTest);
        Dispatch(EventType.CardPlaced);
        return true;
    }
}