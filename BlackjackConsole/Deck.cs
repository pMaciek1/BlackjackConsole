using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class Deck
    {
        public List<Card> cardDeck = new();
        Random random = new Random();
        public List<Card> BuildCardDeck()
        {
            Deck deck = new Deck();
            for (int suits=0; suits<=4; suits++)
            {
                for (int rank=0; rank<=13; rank++)
                {
                    Card card = new Card();
                    card.Suit = ((Enums.Suits)suits).ToString();
                    card.Rank = ((Enums.Ranks)rank).ToString();
                    if (rank > 10)
                    {
                        card.Value = rank;
                    }     
                }
            }
            return ShuffleDeck(deck.cardDeck);
        }
        public List<Card> ShuffleDeck(List<Card> cardDeck)
        {
            int n = cardDeck.Count;
            while (n > 1)
            {
                n--;
                int k=random.Next(n+1);
                Card value = cardDeck[k];
                cardDeck[k] = cardDeck[n];
                cardDeck[n] = value;
            }
            return cardDeck;
        }
        
    }
}
