using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class Deck
    {
        private List<Card> cardDeck = new();
        public List<Card> CardDeck { get => cardDeck; set => cardDeck = value; }
        Random random = new Random();
        public List<Card> BuildCardDeck()
        {
            Deck deck = new Deck();
            for (int suits=0; suits<4; suits++)
            {
                for (int rank=0; rank<13; rank++)
                {
                    Card card = new Card();
                    card.Suit = ((Enums.Suits)suits).ToString();
                    card.Rank = ((Enums.Ranks)rank).ToString();
                    if (rank > 9)
                    {
                        card.Value = 10;
                    }
                    else
                    {
                        card.Value = rank+1;
                    }
                    deck.CardDeck.Add(card);
                }
            }
            return ShuffleDeck(deck.CardDeck);
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
