namespace PujakCardGame;

public interface IHasPriority
{
    public int Priority { get; }
}

public interface ITransitionHandler<TCaller, TTransitionResult> : IHasPriority
{
    public void Handle(TCaller caller, TTransitionResult result);
}

public record TargetingTransitionResult(bool Result);

public interface ITargetingHandler : ITransitionHandler<Card, TargetingTransitionResult> { }

/// <summary>
/// Handles cards attack 
/// </summary>
public interface IAttackHandler : ITransitionHandler<Card, DamageRequest> { }

/// <summary>
/// Handles damaging 
/// </summary>
public interface IDamageHandler : ITransitionHandler<IDamageable, DamageRequest> { }

#nullable enable
/// <summary>
/// Handles spell card playing
/// </summary>
public interface ICastHandler : ITransitionHandler<Card, ITargetable?> { }
#nullable disable