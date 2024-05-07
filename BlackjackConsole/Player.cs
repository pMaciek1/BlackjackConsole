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
    }
}
