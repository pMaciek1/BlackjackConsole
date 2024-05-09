using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class GameModel
    {
        public int GameId { get; set; }
        public string Winner {  get; set; }
        public int PlayerPoints { get; set; }
        public int ComputerPoints { get; set; }
        public List<Card> PlayerCards = new List<Card>();
        public List<Card> ComputerCards = new List<Card>();
    }
    class GameList
    {
        public List<GameModel> Games = new List<GameModel>();
    }
}
