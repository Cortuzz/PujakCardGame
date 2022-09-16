namespace PujakCardGame;

public interface ITargetable
{
    public bool TryTarget(Card targeter);
}