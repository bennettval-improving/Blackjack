using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class Program
    {
        private static Player _player;
        private static Dealer _dealer;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Welcome to the Blackjack table.");

            _player = new Player();
            _dealer = new Dealer();

            var continueGame = true;
            while (continueGame)
            {
                _player.ResetHand();
                _dealer.ResetHand();

                PrintPlayerMoney();

                // deal cards
                _dealer.DealRound(_player);

                // print out table
                PrintTable();

                // check for naturals
                if (_player.GetScore() == 21)
                {
                    PrintPlayerWon(true);
                    _player.Payout(7.5m);
                }
                else
                {
                    bool continueRound = true;
                    while (continueRound)
                    {
                        Console.WriteLine("Would you like to Hit or Stay?");
                        var play = Console.ReadLine();
                        play = play.Trim().ToLower();
                        if (play.Equals("hit"))
                        {
                            var isBust = _dealer.Hit(_player);
                            PrintTable();
                            if (isBust || _player.GetScore() == 21) continueRound = false;
                        }
                        else if (play.Equals("stay"))
                        {
                            _dealer.Play();
                            PrintTable(true);
                            continueRound = false;
                        }
                        else Console.WriteLine("I'm sorry, but I did not understand.");
                    }

                    var playerScore = _player.GetScore();
                    var dealerScore = _dealer.GetScore();
                    if (playerScore > 21 || (dealerScore > playerScore && dealerScore < 22))
                    {
                        PrintDealerWon();
                        _player.Payout(-5);
                    }
                    else if (dealerScore > 21 || playerScore > dealerScore)
                    {
                        PrintPlayerWon();
                        _player.Payout(5);
                    }
                    else
                    {
                        PrintStandOff();
                    }
                }
                PrintPlayerMoney();

                Console.WriteLine("Hit Enter to play again. Type 'exit' to Exit.");
                var continueGameResult = Console.ReadLine();
                continueGame = !continueGameResult.Trim().ToLower().Equals("exit");
            }
        }

        private static void PrintPlayerMoney()
        {
            Console.WriteLine("________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You currently have ${_player.Money}");
            Console.ResetColor();
            Console.WriteLine("________________________________________________________________________\n");
        }

        private static void PrintDealerWon()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Dealer Won!");
            Console.ResetColor();
        }

        private static void PrintPlayerWon(bool playerBlackJacked = false)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (playerBlackJacked) Console.WriteLine("You got a BlackJack! So you automatically win this round.");
            else Console.WriteLine("You Won!");
            Console.ResetColor();
        }

        private static void PrintStandOff()
        {
            Console.WriteLine("Stand Off!");
        }

        private static void PrintTable(bool showDealerHand = false)
        {
            var hand = "";
            Console.WriteLine("________________________________________________________________________\n");

            Console.WriteLine("Player: ");
            _player.Hand.ForEach(card =>
            {
                if (_player.Hand.IndexOf(card) == 0) hand += card.ToString();
                else hand += (", " + card.ToString());
            });
            Console.WriteLine($"\t{hand}\n");

            Console.WriteLine("\nDealer: ");
            hand = "";
            var dealerHand = _dealer.GetHand(showDealerHand);
            for (int i = 0; i < dealerHand.Count; i ++)
            {
                if (i == 0) hand += dealerHand[i].ToString();
                else hand += (", " + dealerHand[i].ToString());
            };
            Console.WriteLine($"\t{hand}\n");

            Console.WriteLine("________________________________________________________________________\n");
        }

        //private static bool HitOrStay()
        //{
        //    Console.WriteLine("Would you like to Hit or Stay?");
        //    var play = Console.ReadLine();
        //    if (play.Trim().ToLower().Equals("hit"))
        //    {
        //        var isBust = _dealer.Hit(_player);
        //        // if (isBust) end round and take money
        //    }
        //    else _dealer.Stay(_player);
        //}

        private static void Bust()
        {

        }

    }
}
