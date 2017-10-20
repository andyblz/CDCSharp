using System;
using System.Collections.Generic;

namespace DeckOfCardsAssignment
{
    public class Player {
        // Give the Player class a name property.
        public string playerName;

        // Give the Player a hand property that is a list of type Card.
        List<Card> hand = new List<Card>();


        public Player(string name)
        {
            playerName = name;
        }

        // Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card.
        public Card Draw(Deck game)
        {
            hand.Add(game.Deal());
            Console.WriteLine(hand[hand.Count - 1]);
            return hand[hand.Count - 1];
        }

        // Give the Player a discard method which discards the Card at the specified index from the player's hand, and returns this Card or null if the index doesn't exist.
        public Card Discard(int index)
        {
            Console.WriteLine(hand.Count);
            if (hand.Count > index)
            {
                Card temp = hand[index];
                hand.RemoveAt(index);
                Console.WriteLine("Card was discarded: {0}", temp);
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
}