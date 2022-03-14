// <copyright file="Deck.cs" company="rdbehlmann@gmail.com">
// Copyright (c) rdbehlmann@gmail.com. All rights reserved.
// </copyright>
namespace DeckOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representing a deck of cards with functionality to shuffle and draw.
    /// </summary>
    public class Deck
    {
        public record Card
        {
            /// <summary>
            /// Gets or sets suite of card.
            /// </summary>
            public Enum.CardSuite Suite { get; set; }

            /// <summary>
            /// Gets or sets face value of card.
            /// </summary>
            public Enum.CardValue FaceValue { get; set; }
        }

        private List<Card> cards;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class.
        /// </summary>
        public Deck()
        {
            this.Shuffle();
        }

        /// <summary>
        /// Gets the number of remaining cards left in the card deck.
        /// </summary>
        public int RemainingCards
        {
            get
            {
                //Comment for giggles via Safari browser
                return this.cards!.Count;
            }
        }

        /// <summary>
        /// Sets the cards object with a new random set of all enumberable combinations from CardSuite and CardValue.
        /// </summary>
        public void Shuffle()
        {
            Random random = new ();
            this.cards = ((IEnumerable<Enum.CardSuite>)System.Enum.GetValues(typeof(Enum.CardSuite))).SelectMany(x =>
                        ((IEnumerable<Enum.CardValue>)System.Enum.GetValues(typeof(Enum.CardValue))).Select(y =>
                                new Card() { Suite = x, FaceValue = y }))
                        .OrderBy<Card, int>(c => random.Next()).ToList();
        }

        /// <summary>
        /// Overload to draw 1 card from cards list.
        /// </summary>
        /// <returns>The drawn card.</returns>
        public Card Draw()
        {
            return this.Draw(1).FirstOrDefault();
        }

        /// <summary>
        /// Function to draw cards remaining in cards list.
        /// </summary>
        /// <param name="cardCount">Amount of cards to return.</param>
        /// <returns>List of cards drawn.</returns>
        public List<Card> Draw(int cardCount)
        {
            List<Card> temp = new ();
            if (cardCount > this.cards.Count)
            {
                Console.WriteLine($"Request draw count exceeds deck length. Remaining {this.cards.Count} cards returned.");
                temp = this.cards;
                this.cards = new ();
            }
            else if (cardCount > 0)
            {
                temp = this.cards.Take(cardCount).ToList();
                this.cards.RemoveRange(0, cardCount);
            }

            return temp;
        }
    }
}