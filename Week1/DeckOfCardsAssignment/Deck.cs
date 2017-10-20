using System;
using System.Collections.Generic;

namespace DeckOfCardsAssignment
{
    public class Deck 
    {
        // Give the Deck class a property called "cards", which is a list of Card objects.
        List<Card> cards = new List<Card>();
        List<Card> discards = new List<Card>();
        Random rand = new Random();

        // When initializing the deck, make sure that it has a list of 52 unique cards as its "cards" property.
        public Deck()
        {
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Card newDeck = new Card(x, y);
                    cards.Add(newDeck);
                    Console.WriteLine("{0} Adding this card to the deck: {1}", ((x + 1) * (y + 1)), newDeck);
                }
            }
        }

        // Give the Deck a deal method that selects the top-most card, removes it from the list of cards, and returns the Card.
        public Card Deal()
        {
            Card dealtCard = cards[0];
            discards.Add(dealtCard);
            cards.RemoveAt(0);
            Console.WriteLine("Card was dealt: {0}", dealtCard);
            return dealtCard;
        }

        // Give the Deck a reset method that resets the cards property to contain the original 52 cards.
        public void Reset()
        {
            Console.WriteLine("Reseting deck...");
            for (int i = 0; i < discards.Count; i++)
            {
                cards.Add(discards[i]);
                discards.RemoveAt(i);
            }
        }

        // Give the Deck a shuffle method that randomly reorders the deck's cards.
        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int idx = rand.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[idx];
                cards[idx] = temp;
            }
            Console.WriteLine("Cards were shuffled.");
        }
    
    }
}