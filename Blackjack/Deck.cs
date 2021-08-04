using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        private List<Card> _cards;
        public List<Card> Cards => _cards;

        public Deck()
        {
            _cards = GetCards();
        }

        public void ShuffleCards()
        {
            _cards = _cards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private List<Card> GetCards()
        {
            var cards = new List<Card>();
            for (int i = 2; i < 15; i++)
            {
                if (i < 11)
                {
                    cards.AddRange(new List<Card>
                    {
                        new Card { Name = i.ToString(), Suit = Suit.Club, Value = i },
                        new Card { Name = i.ToString(), Suit = Suit.Diamond, Value = i },
                        new Card { Name = i.ToString(), Suit = Suit.Heart, Value = i },
                        new Card { Name = i.ToString(), Suit = Suit.Spade, Value = i }
                    });
                }
                else if (i == 11)
                {
                    cards.AddRange(new List<Card>
                    {
                        new Card { Name = "Jack", Suit = Suit.Club, Value = 10 },
                        new Card { Name = "Jack", Suit = Suit.Diamond, Value = 10 },
                        new Card { Name = "Jack", Suit = Suit.Heart, Value = 10 },
                        new Card { Name = "Jack", Suit = Suit.Spade, Value = 10 }
                    });
                }
                else if (i == 12)
                {
                    cards.AddRange(new List<Card>
                    {
                        new Card { Name = "Queen", Suit = Suit.Club, Value = 10 },
                        new Card { Name = "Queen", Suit = Suit.Diamond, Value = 10 },
                        new Card { Name = "Queen", Suit = Suit.Heart, Value = 10 },
                        new Card { Name = "Queen", Suit = Suit.Spade, Value = 10 }
                    });
                }
                else if (i == 13)
                {
                    cards.AddRange(new List<Card>
                    {
                        new Card { Name = "King", Suit = Suit.Club, Value = 10 },
                        new Card { Name = "King", Suit = Suit.Diamond, Value = 10 },
                        new Card { Name = "King", Suit = Suit.Heart, Value = 10 },
                        new Card { Name = "King", Suit = Suit.Spade, Value = 10 }
                    });
                }
                else if (i == 14)
                {
                    cards.AddRange(new List<Card>
                    {
                        new Card { Name = "Ace", Suit = Suit.Club, Value = 11 },
                        new Card { Name = "Ace", Suit = Suit.Diamond, Value = 11 },
                        new Card { Name = "Ace", Suit = Suit.Heart, Value = 11 },
                        new Card { Name = "Ace", Suit = Suit.Spade, Value = 11 }
                    });
                }
            }
            return cards;
        }
    }
}
