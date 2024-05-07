namespace BlackjackConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isGame = true;
            bool gameOver = false;
            Dealer dealer = new Dealer();
            Player player = new Player();
            int playerPoints=0;
            Console.WriteLine("Blackjack game! :)");
            Console.ReadLine();
            while (isGame)
            {
                Deck deck = new Deck();
                /*while (gameOver == false)
                {

                }*/
                deck.CardDeck = deck.BuildCardDeck();
                dealer.DealCard(deck, player);
                playerPoints = player.GetPlayerPoints();
                Console.WriteLine($"Your current points are {playerPoints}");
                if(playerPoints >= 21)
                {
                    break;
                }
                Console.Write("Do you want to draw? y/n: ");
                string playerDecision = Console.ReadLine();
                if (playerDecision=="n")
                {
                    isGame= false;
                }
            }
            if(playerPoints == 21)
            {
                Console.WriteLine("You win!");
            }
            else if(playerPoints > 21)
            {
                Console.WriteLine("You lose!");
            }
        }
    }
}
