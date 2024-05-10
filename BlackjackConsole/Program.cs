namespace BlackjackConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isMenu = true;
            bool isGame;
            bool gameOver;
            Dealer dealer = new Dealer();
            Player player = new Player();
            Player computer = new Player();
            GameList gameList = new GameList();
            int playerPoints = 0;
            int computerPoints = 0;
            int computerTotal = 0;
            int gameNumber = 1;
            Console.WriteLine("Blackjack game! :)");
            Console.Write("Press any key to enter the menu");
            Console.ReadKey();
            while (isMenu)
            {
                Console.WriteLine("\n1-Start new game\n2-View game history\n3-Exit the game");
                string playerDecision = Console.ReadLine();
                switch(playerDecision)
                {
                    case "1":
                        Console.Clear();
                        isGame = true;
                        gameOver = false;
                        Game();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        History();
                        Console.Clear();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            void Game()
            {
                while (isGame)
                {
                    Deck deck = new Deck();
                    GameModel game = new GameModel();
                    while (gameOver == false)
                    {

                        Console.Clear();
                        Console.WriteLine($"Game ID: {gameNumber}");
                        deck.CardDeck = deck.BuildCardDeck();
                        dealer.DealCard(deck, player, "Player");
                        Player.ComputerDraw(computerTotal, deck, computer, dealer);
                        playerPoints = player.GetPlayerPoints();
                        computerPoints = computer.GetComputerPoints();
                        computerTotal = computer.GetPlayerPoints();
                        Console.WriteLine($"\n\n\nYour current points are {playerPoints} (with aces counting as 1)");
                        Console.WriteLine($"Computer's current points are {computerPoints} (without the first card and aces counting as 1)");
                        if (playerPoints >= 21)
                        {
                            break;
                        }
                        string playerDecision = "";
                        while (playerDecision != "y" && playerDecision != "n")
                        {
                            Console.Write("\n\nDo you want to draw? y/n: ");
                            playerDecision = Console.ReadLine();
                        }
                        if (playerDecision == "n")
                        {
                            while (computerTotal < 16)
                            {
                                Player.ComputerDraw(computerTotal, deck, computer, dealer);
                                computerTotal = computer.GetPlayerPoints();
                            }
                            Console.WriteLine("\nComputer decides to hold");
                            gameOver = true;
                        }
                    }
                    Console.WriteLine("\n\n\nGame is over. Let's count the points");
                    player.PlayerAces();
                    computer.ComputerAces();
                    playerPoints = player.GetPlayerPoints();
                    computerTotal = computer.GetPlayerPoints();
                    Console.WriteLine($"\nComputer's first card was {computer.playerHand.First().Rank} of {computer.playerHand.First().Suit}");
                    game.Winner = WhoWins(playerPoints, computerTotal);
                    game.PlayerPoints = playerPoints;
                    game.ComputerPoints = computerTotal;
                    game.PlayerCards.AddRange(player.playerHand);
                    game.ComputerCards.AddRange(computer.playerHand);
                    game.GameId = gameNumber;
                    gameList.Games.Add(game);
                    string decision = "";
                    while (decision != "y" && decision != "n")
                    {
                        Console.Write("\n\n\nDo you want to play another game? y/n: ");
                        decision = Console.ReadLine();
                    }
                    if (decision == "n")
                    {
                        isGame = false;
                    }
                    player.playerHand.Clear();
                    computer.playerHand.Clear();
                    computerTotal = 0;
                    playerPoints = 0;
                    computerPoints = 0;
                    gameNumber++;
                    gameOver = false;
                }
            }
            void History()
            {
                if(gameList.Games.Count > 0)
                {
                    foreach(GameModel game in gameList.Games)
                    {
                        Console.WriteLine($"\n\nGame ID: {game.GameId}\nWinner: {game.Winner}\nPlayer points: {game.PlayerPoints}\nComputer points: {game.ComputerPoints}");
                        Console.Write($"Player cards: ");
                        foreach(Card card in game.PlayerCards)
                        {
                            Console.Write($"{card.Rank} of {card.Suit}, ");
                        }
                        Console.Write($"\b \b\b \b\nComputer cards: ");
                        foreach (Card card in game.ComputerCards)
                        {
                            Console.Write($"{card.Rank} of {card.Suit}, ");
                        }
                        Console.Write($"\b \b\b \b");
                    }
                }
                else
                {
                    Console.WriteLine("No played games yet");
                }
                Console.Write("\n\nPress any key to return to the main menu");
                Console.ReadKey();
            }
            string WhoWins(int playerPoints, int computerTotal)
            {
                Console.WriteLine($"\n\n\nComputer's total points are {computerTotal}");
                Console.WriteLine($"\nPlayer's total points are {playerPoints}");
                if (playerPoints == 21)
                {
                    Console.WriteLine("\nYou win by having blackjack! Congrats!");
                    return "Player";
                }
                else if (playerPoints > 21)
                {
                    Console.WriteLine("\nYour total points are greater than 21! You lose!");
                    return "Computer";
                }
                else
                {
                    if (computerTotal > 21)
                    {
                        Console.WriteLine("You win, computer has more than 21");
                        return "Player";
                    }
                    else
                    {
                        if (playerPoints > computerTotal)
                        {
                            Console.WriteLine("\nYou win by having more points than compuer!");
                            return "Player";
                        }
                        else if (computerTotal > playerPoints)
                        {
                            Console.WriteLine("\nComputer wins by having more points than you!");
                            return "Computer";
                        }
                        else
                        {
                            Console.WriteLine("\nDraw!");
                            return "Draw";
                        }
                    }

                }
            }
        }
        
    }
}
