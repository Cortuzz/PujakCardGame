namespace PujakCardGame.client;

public class TestModifier : Modifier
{
    
    public string Name { get; set; }
    public override Card Card { get; set; }

    public TestModifier(Card card)
    {
        Card = card;
        card.CardPlayed += Update;
    }

    private void Update(object card, Hero caster)
    {
        System.Diagnostics.Debug.Write("\n\n\nЯ отработал)\n\n\n");
    }

    ~TestModifier()
    {
        Card.CardPlayed -= Update;
    }
}