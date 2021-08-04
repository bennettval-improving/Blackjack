using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        private decimal _money;
        public decimal Money => _money;
        public List<Card> Hand { get; set; }
        public bool IsDealer { get; } = false;

        public Player()
        {
            Hand = new List<Card>();
            _money = 100;
            IsDealer = false;
        }

        public void Payout(decimal payout)
        {
            _money += payout;
        }

        public bool IsBust() => GetScore() > 21;

        public int GetScore()
        {
            var score = Hand.Aggregate(0, (total, card) => total + card.Value);
            if (score > 21)
            {
                var aceCount = Hand.Where(x => x.Name.Trim().ToLower().Equals("ace")).Count();
                if (aceCount < 1) return score;
                for (int i = 0; i < aceCount; i++)
                {
                    score -= 10;
                    if (score <= 21) return score;
                }
            }
            return score;
        }

        public void ResetHand()
        {
            Hand = new List<Card>();
        }
    }
}
