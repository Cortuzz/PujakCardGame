using System.IO;
using System.Text.Json;
using PujakCardGame;

using (var stream = File.OpenRead("CardsScemas/cards.json"))
    CardsDirector.Instance.ProcessScema(JsonSerializer.Deserialize<CardsScema>(stream));

using var game = new PujakCardGame.CardGame();
game.Run();