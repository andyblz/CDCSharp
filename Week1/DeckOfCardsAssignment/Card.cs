using System;
using System.Collections.Generic;

namespace DeckOfCardsAssignment
{
    public class Card 
    {
        public string cardSuit;
        public string cardFace;

        // Give the Card class a property "stringVal" which will hold the value of the card. Value should be a string. (e.g., Ace, 2, 3..., Queen, King).
        // Give the Card a property "val", which will hold the numerical value of the card 1-13 as integers.
       public string[] stringVal = {"Ace", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

        // Give the Card a property "suit", which will hold the suit of the card (e.g., Club, Spades, Hearts, Diamonds).
        public string[] suitVal = {"Clubs", "Spades", "Hearts", "Diamonds"};


        // Card constructor.
        public Card(int face, int suit) 
        {
            cardFace = stringVal[face];
            cardSuit = suitVal[suit];
        }
    }
}