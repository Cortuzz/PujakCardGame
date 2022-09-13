namespace PujakCardGame.client;

public class TestModifier : Modifier
{
    public TestModifier(AbstractCard card)
    {
        Card = card;
        card.Subscribe(this);
    }

    public override void Update(IObservable observable, EventType et)
    {
        if (et != EventType.CardPlaced)
            return;
        
        System.Diagnostics.Debug.Write("\n\n\nЯ отработал)\n\n\n");
    }

    ~TestModifier()
    {
        Card.Unsubscribe(this);
    }
}