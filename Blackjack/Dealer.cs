using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer
    {
        private Deck _deck;
        private List<Card> _hand;

        public Dealer()
        {
            _hand = new List<Card>();
            _deck = new Deck();
        }

        public void ResetHand()
        {
            _hand = new List<Card>();
        }

        public List<Card> GetHand(bool showAllCards = false)
        {
            if (_hand.Count < 1) return _hand;
            if (showAllCards)
            {
                return _hand;
            }
            var hand = _hand.GetRange(0, _hand.Count - 1);
            hand.Add(new Card { Name = "?", Suit = Suit.Undefined });
            return hand;
        }

        public void DealRound(Player player)
        {
            _deck = new Deck();
            _deck.ShuffleCards();

            DealCardToPlayer(player);
            DealCardToDealer();
            DealCardToPlayer(player);
            DealCardToDealer();
        }

        public bool Hit(Player player)
        {
            DealCardToPlayer(player);
            return player.IsBust();
        }

        public void Play()
        {
            var score = GetScore();
            while (score < 17)
            {
                DealCardToDealer();
                score = GetScore();
            }
        }

        public int GetScore()
        {
            var score = _hand.Aggregate(0, (total, card) => total + card.Value);
            if (score > 21)
            {
                var aceCount = _hand.Where(x => x.Name.Trim().ToLower().Equals("ace")).Count();
                if (aceCount < 1) return score;
                for (int i = 0; i < aceCount; i++)
                {
                    score -= 10;
                    if (score <= 21) return score;
                }
            }
            return score;
        }

        private void DealCardToPlayer(Player player)
        {
            var cardToDeal = _deck.Cards.FirstOrDefault();
            _deck.Cards.Remove(cardToDeal);
            player.Hand.Add(cardToDeal);
        }

        private void DealCardToDealer()
        {
            var cardToDeal = _deck.Cards.FirstOrDefault();
            _deck.Cards.Remove(cardToDeal);
            _hand.Add(cardToDeal);
        }
    }
}
