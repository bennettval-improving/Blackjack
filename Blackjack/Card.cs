using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public Suit Suit { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Name} of {GetUnicodeSuit(Suit)}";
        }

        private string GetUnicodeSuit(Suit suit)
        {
            switch (suit)
            {
                case Suit.Club:
                    return "♣";
                    //return "\u0005";
                case Suit.Diamond:
                    return "♦";
                    //return "\u0004";
                case Suit.Heart:
                    return "♥";
                    //return "\u0003";
                case Suit.Spade:
                    return "♠";
                    //return "\u0006";
                default:
                    return "?";
            }
        }
    }
}
