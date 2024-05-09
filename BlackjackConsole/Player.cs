using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class Player
    {
        public List<Card> playerHand = new List<Card>();
        public int GetPlayerPoints()
        {
            int points = 0;
            foreach(Card card in playerHand)
            {
                points += card.Value;
            }
            return points;
        }
        public int GetComputerPoints()
        {
            int points = 0;
            var firstCard = playerHand.First();
            foreach (Card card in playerHand)
            {
                points += card.Value;
            }
            points -= firstCard.Value;
            return points;
        }
        public void PlayerAces() //fixed :)
        {
            List<Card> aces = playerHand.FindAll(x => x.Rank == "Ace");
            if (aces.Count > 0)
            {
                Console.WriteLine($"You have {aces.Count} aces in hand");
                int count = 0;
                foreach(Card ace in aces)
                {
                    playerHand.Remove(playerHand.FindLast(x => x.Rank == "Ace"));
                    count++;
                    Console.WriteLine($"\n\n{count} ACE:");
                    string decision = "";
                    while (decision != "y" && decision != "n")
                    {
                        Console.Write("How do you want the ace to count? y-1/n-11: ");
                        decision = Console.ReadLine();
                    }
                    if (decision == "n")
                    {
                        ace.Value = 11;
                    }
                    playerHand.Add(ace);
                }
            }
        }
        public void ComputerAces()
        {
            List<Card> aces = playerHand.FindAll(x => x.Rank == "Ace");
            if (aces.Count > 0)
            {
                Console.WriteLine($"Computer have {aces.Count} aces in hand");
                int count = 0;
                foreach (Card ace in aces)
                {
                    count++;
                    Console.WriteLine($"\n\n{count} ACE:");
                    if (GetComputerPoints() < 11)
                    {
                        ace.Value = 11;
                    }
                    Console.WriteLine($"Computer decided that the ace counts as {ace.Value}");
                }
            }
        }
        public static void ComputerDraw(int computerTotal, Deck deck, Player computer, Dealer dealer)
        {
            if (computerTotal == 0)
            {
                dealer.DealFirstCard(deck, computer);
            }
            else if (computerTotal <= 15)
            {
                Console.WriteLine("\nComputer decides to draw");
                dealer.DealCard(deck, computer, "Computer");
            }
            else
            {
                Console.WriteLine("\nComputer decides to hold");
            }
        }
    }
}
