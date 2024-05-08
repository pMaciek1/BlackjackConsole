using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    
    class Dealer
    {
        private Random rnd = new Random();
        private int randomCard = 0;
        
        public void DealCard(Deck deck, Player player, string name)
        {
            randomCard=rnd.Next(deck.CardDeck.Count);
            player.playerHand.Add(deck.CardDeck[randomCard]);
            Console.WriteLine($"{name} have been dealt {deck.CardDeck[randomCard].Rank} of {deck.CardDeck[randomCard].Suit}");
        }
        public void DealFirstCard(Deck deck, Player player)
        {
            randomCard = rnd.Next(deck.CardDeck.Count);
            player.playerHand.Add(deck.CardDeck[randomCard]);
        }
    }
}
