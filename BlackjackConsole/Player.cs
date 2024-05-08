using System;
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
        public void PlayerAces() //TODO !!!!!!!!!!!!!!!!! FIX IT, DOESNT ADD TEN POINTS WHEN IT SHGOUDL TODO!
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
                    Console.Write("How do you want the ace to count? y-1/n-11");
                    string decision = Console.ReadLine();
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
    }
}
