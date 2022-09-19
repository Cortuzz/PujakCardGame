using System.Diagnostics;

namespace PujakCardGame.ConcreteModifiers;

public class TestModifier : Modifier<Card>, IAttackHandler, ITargetingHandler
{
    public int Priority => int.MinValue;

    public override string Name => GetType().Name;

    private void _onCardPlayed(object card, Hero caster)
    {
        Debug.Write(Name + " handled Played event on card");
    }

    public void Handle(Card caller, TargetingTransitionResult result)
    {
        Debug.WriteLine(Name + " did nothing on targeting");
    }

    public void Handle(Card caller, DamageRequest result)
    {
        result.Damage = result.Damage with { Amount = result.Damage.Amount + 1 };
        Debug.WriteLine(Name + " adds 1 damage unit");
    }

    protected override void _onTargetAttached()
    {
        Target.Played += _onCardPlayed;
    }

    protected override void _onTargetDetaching()
    {
        Target.Played -= _onCardPlayed;
    }

    public TestModifier() { }
    public TestModifier(double argument)
    {
        Debug.WriteLine(GetType().Name + " was creted with argument " + argument);
    }

    ~TestModifier()
    {
        if (_target is Card card)
            card.Played -= _onCardPlayed;
    }
}