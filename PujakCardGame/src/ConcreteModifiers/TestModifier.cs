namespace PujakCardGame.ConcreteModifiers;

public class TestModifier : Modifier, IAttackHandler, ITargetingHandler
{
    
    public string Name { get; set; }
    public override Card Card { get; set; }

    public int Priority => throw new System.NotImplementedException();

    public TestModifier(Card card)
    {
        Card = card;
        card.CardPlayed += Update;
    }

    private void Update(object card, Hero caster)
    {
        System.Diagnostics.Debug.Write("\n\n\nЯ отработал)\n\n\n");
    }

    public void Handle(Card caller, TargetingTransitionResult result)
    {
        throw new System.NotImplementedException();
    }

    public void Handle(Card caller, Damage result)
    {
        throw new System.NotImplementedException();
    }

    ~TestModifier()
    {
        Card.CardPlayed -= Update;
    }
}