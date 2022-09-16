namespace PujakCardGame.ConcreteModifiers;

public class TestModifier : Modifier<Card>, IAttackHandler, ITargetingHandler
{
    public int Priority => int.MinValue;

    public override string Name => GetType().Name;

    private void _onCardPlayed(object card, Hero caster)
    {
        System.Diagnostics.Debug.Write("\n\n\nЯ отработал)\n\n\n");
    }

    public void Handle(Card caller, TargetingTransitionResult result)
    {
        throw new System.NotImplementedException();
    }

    public void Handle(Card caller, DamageRequest result)
    {
        throw new System.NotImplementedException();
    }

    protected override void _onTargetAttached()
    {
        Target.CardPlayed += _onCardPlayed;
    }

    protected override void _onTargetDetaching()
    {
        Target.CardPlayed -= _onCardPlayed;
    }

    ~TestModifier()
    {
        if (_target is Card card)
            card.CardPlayed -= _onCardPlayed;
    }
}