namespace PujakCardGame;

public interface ITargetable
{
    public bool TryTarget(ITargetable targeter);
}