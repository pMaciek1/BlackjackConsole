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
            Player computer = new Player();
            int playerPoints = 0;
            int computerPoints = 0;
            int computerTotal = 0;
            Console.WriteLine("Blackjack game! :)");
            Console.ReadLine();
            while (isGame)
            {
                Deck deck = new Deck();
                while (gameOver == false)
                {
                    
                    Console.Clear();
                    deck.CardDeck = deck.BuildCardDeck();
                    dealer.DealCard(deck, player, "Player");
                    if(computerTotal == 0)
                    {
                        dealer.DealFirstCard(deck, computer);
                    }
                    else if(computerTotal <= 15)
                    {
                        Console.WriteLine("Computer decides to draw");
                        dealer.DealCard(deck, computer, "Computer");
                    }
                    else
                    {
                        Console.WriteLine("Computer decides to hold");
                    }
                    
                    playerPoints = player.GetPlayerPoints();
                    computerPoints = computer.GetComputerPoints();
                    computerTotal = computer.GetPlayerPoints();
                    Console.WriteLine($"\n\n\nYour current points are {playerPoints} (with aces counting as 1)");
                    Console.WriteLine($"Computer's current points are {computerPoints} (without the first card and aces counting as 1)");
                    if (playerPoints >= 21)
                    {
                        break;
                    }
                    Console.Write("\n\nDo you want to draw? y/n: ");
                    string playerDecision = Console.ReadLine();
                    if (playerDecision == "n")
                    {
                        gameOver = true;
                    }
                }
                player.PlayerAces();
                computer.ComputerAces();
                computerTotal = computer.GetPlayerPoints();
                Console.WriteLine($"\n\n\nComputer's total points are {computerTotal}");
                Console.WriteLine($"\nPlayer's total points are {playerPoints}");
                if (playerPoints == 21)
                {
                    Console.WriteLine("\nYou win by having blackjack! Congrats!");
                }
                else if (playerPoints > 21)
                {
                    Console.WriteLine("\nYour total points are greater than 21! You lose!");
                }
                else
                {
                    if (computerPoints > 21)
                    {
                        Console.WriteLine("You win, computer have more than 21");
                    }
                    else
                    {
                        if (playerPoints > computerTotal)
                        {
                            Console.WriteLine("\nYou win by having more points than compuer!");
                        }
                        else if (computerTotal > playerPoints)
                        {
                            Console.WriteLine("\nComputer wins by having more points than you!");
                        }
                        else
                        {
                            Console.WriteLine("\nDraw!");
                        }
                    }
                    
                }
                Console.Write("\n\n\nDo you want to play another game? y/n");
                string decision = Console.ReadLine();
                if (decision == "n")
                {
                    isGame = false;
                }
                player.playerHand.Clear();
                computer.playerHand.Clear();
                computerTotal = 0;
                playerPoints = 0;
                computerPoints = 0;
                gameOver = false;
            }
            
        }
    }
}
