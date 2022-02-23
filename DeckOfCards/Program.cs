// <copyright file="Program.cs" company="rdbehlmann@gmail.com">
// Copyright (c) rdbehlmann@gmail.com. All rights reserved.
// </copyright>
namespace DeckOfCards
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Startup class for console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for console application.
        /// </summary>
        public static void Main()
        {
            PrintUsage();
            DeckOfCards.Deck deck = new ();
            string response = string.Empty;
            do
            {
                response = Console.ReadLine().ToUpper();
                if (int.TryParse(response, out int cardCount))
                {
                    List<Deck.Card> temp = deck.Draw(cardCount);
                    temp.ForEach(x => Console.WriteLine($"{x.FaceValue} of {x.Suite}"));
                }
                else
                {
                    switch (response.Substring(0, 1))
                    {
                        case "I":
                            Console.WriteLine($"{deck.RemainingCards} card(s) remaining in the deck.");
                            break;
                        case "Q":
                            break;
                        case "R":
                            deck.Shuffle();
                            Console.WriteLine($"Deck has been reshuffled.");
                            break;
                        default:
                            Console.WriteLine("Invalid input provided. Please try again or press enter to exit.");
                            break;
                    }
                }

                Console.WriteLine();
            }
            while (!string.IsNullOrEmpty(response) && response.Substring(0, 1) != "Q");
        }

        private static void PrintUsage()
        {
            Console.WriteLine("The \"Deck Of Cards\" application displays values represent a deck of cards with operations to shuffle the deck and to deal one to the maximimum number of cards remaining in the deck.\n\n" +
                "Respond to the prompts to from the application to draw a number of cards, shuffle / reshuffle, or get the remaining number of cards.\n" +
                "Using the following options:\nType a number greater than zero to display the drawn cards\nType 'I' to display the number of cards remaining in the deck\n" +
                "Type 'R' to reshuffle the deck\nType 'Q' to quit");
        }
    }
}
