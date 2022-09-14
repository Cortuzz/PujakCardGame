using System;

namespace PujakCardGame;

public interface TransitionHandler<TCaller, TTransitionResult>
{
    public int Priority { get; }
    public void Handle(TCaller caller, TTransitionResult result);
}


public record TargetingTransitionResult(bool Result);

public interface ITargetingHandler : TransitionHandler<Card, TargetingTransitionResult> { }

public interface IAttackHandler : TransitionHandler<Card, Damage> { }