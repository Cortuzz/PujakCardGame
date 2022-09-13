﻿using System;
using PujakCardGame;
using PujakCardGame.client;

Card card = new UnitCard("Говно");
Modifier modifier = new TestModifier(card);
card.PlayCard(null, null, null);

using var game = new PujakCardGame.CardGame();
game.Run();