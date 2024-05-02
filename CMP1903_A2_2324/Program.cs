namespace CMP1903_A2_2324
{
    internal class Program
    {
        private static readonly string[] _twoPlayerMenu = { "One Player", "Two Player" };
        
        private static bool TwoPlayer(InputOutputManager io)
        {
            (bool, int) twoPlayerOption = io.HandleMenu(_twoPlayerMenu);

            if (!twoPlayerOption.Item1)
            {
                twoPlayerOption = io.HandleMenu(_twoPlayerMenu);
            }

            return twoPlayerOption.Item2 != 0;
        }
        
        public static void Main(string[] args)
        {
            Statistics statsManager = new Statistics();
            SevensOut sevensOut = new SevensOut();
            ThreeOrMore threeOrMore = new ThreeOrMore();
            InputOutputManager io = new InputOutputManager();
        
            string[] menuOptions =
            {
                "Play Three Or More",
                "Play Sevens Out",
                "View Current Statistics",
                "Test the Program",
                "Exit"
            };
            
            while (true)
            {
                (bool, int) optionChosen = io.HandleMenu(menuOptions);

                if (!optionChosen.Item1)
                {
                    optionChosen = io.HandleMenu(menuOptions);
                }

                bool twoPlayer = false;

                if (optionChosen.Item2 == 0 || optionChosen.Item2 == 1)
                {
                    twoPlayer = TwoPlayer(io);
                }
                
                switch (optionChosen.Item2)
                {
                    case 0:
                        (int playerOneScore, int playerTwoScore, int lastScore) = threeOrMore.playGame(twoPlayer);

                        (string statisticName, int highestScore) =
                            statsManager.GetStatistic(Statistics.StatisticCodes.ThreeOrMoreHighScore);

                        if (playerOneScore > highestScore)
                        {
                            statsManager.UpdateStatistic(Statistics.StatisticCodes.ThreeOrMoreHighScore,
                                playerOneScore);
                        }

                        if (!twoPlayer && playerTwoScore > highestScore)
                        {
                            statsManager.UpdateStatistic(Statistics.StatisticCodes.ThreeOrMoreHighScore,
                                playerTwoScore);
                        }

                        statsManager.UpdateStatistic(Statistics.StatisticCodes.ThreeOrMorePlayCount, 1, true);
                        
                        break;
                    case 1:
                        
                        
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                        
                }
            }
        }
    }
    
}