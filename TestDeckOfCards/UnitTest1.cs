using NUnit.Framework;
using System.Collections.Generic;

namespace TestDeckOfCards
{
    public class Tests
    {
        [Test]
        public void TestDrawOne()
        {
            DeckOfCards.Deck deck = new();
            deck.Draw();
            Assert.AreEqual(deck.RemainingCards, 51);
        }

        [Test]
        public void TestNegativeNumber()
        {
            DeckOfCards.Deck deck = new ();
            List<DeckOfCards.Deck.Card> temp = deck.Draw(-1);
            Assert.AreEqual(temp, new List<DeckOfCards.Deck.Card>());
        }

        [Test]
        public void TestPositiveNumber()
        {
            DeckOfCards.Deck deck = new ();
            List<DeckOfCards.Deck.Card> temp = deck.Draw(5);
            Assert.AreEqual(temp.Count, 5);
        }

        [Test]
        public void TestReshuffle()
        {
            DeckOfCards.Deck deck = new ();
            deck.Draw(52);
            int remainingCount = deck.RemainingCards;
            if (remainingCount != 0) Assert.Fail("Draw failed");
            else
            {
                deck.Shuffle();
                Assert.AreEqual(deck.RemainingCards, 52);
            }
        }
    }
}