using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CMP1903_A2_2324
{
    public class ThreeOrMore : Game
    {
        private Die _dieOne = new Die();
        private Die _dieTwo = new Die();
        private Die _dieThree = new Die();
        private Die _dieFour = new Die();
        private Die _dieFive = new Die();

        private List<int> RollFiveDie()
        {
            List<int> returnList = new List<int>();
            returnList.Add(_dieOne.Roll());
            returnList.Add(_dieTwo.Roll());
            returnList.Add(_dieThree.Roll());
            returnList.Add(_dieFour.Roll());
            returnList.Add(_dieFive.Roll());

            return returnList;
        }

        private List<int> RollThreeDie(List<int> currentDieList, int repeatedValue)
        {
            IEnumerable<int> indexesOfCorrectRolls = Enumerable.Range(0, currentDieList.Count)
                .Where(index => currentDieList[index] == repeatedValue)
                .ToList();

            foreach (int index in indexesOfCorrectRolls)
            {
                int replacementRoll = 0;

                switch (index + 1)
                {
                    case 1:
                        replacementRoll = _dieOne.Roll();
                        break;
                    case 2:
                        replacementRoll = _dieTwo.Roll();
                        break;
                    case 3:
                        replacementRoll = _dieThree.Roll();
                        break;
                    case 4:
                        replacementRoll = _dieFour.Roll();
                        break;
                    case 5:
                        replacementRoll = _dieFive.Roll();
                        break;
                }
                
                Console.WriteLine($"Dice {index + 1} Roll: {replacementRoll}"); 
                
                currentDieList[index] = replacementRoll;
            }

            return currentDieList;
        }

        private (int action, int repeatRoll) CourseOfAction(List<int> dice)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();
            
            foreach (int number in dice)
            {
                if (!numberCount.ContainsKey(number))
                {
                    numberCount.Add(number, 0);
                }
                
                numberCount[number] += 1;
            }

            int highestKeyValue = numberCount
                .Aggregate((entryOne, entryTwo) => entryOne.Value > entryTwo.Value ? entryOne : entryTwo).Key;

            switch (highestKeyValue)
            {
                case 2:
                    return (1, highestKeyValue);
                case 3:
                    return (2, highestKeyValue);
                case 4:
                    return(3, highestKeyValue);
                case 5:
                    return (4, highestKeyValue);
                default:
                    return (0, 0);
            }
        }
        
        public override (int, int, int) playGame(bool twoPlayer)
        {
            int playerOneScore = 0;
            int playerOneRounds = 0;

            int playerTwoScore = 0;
            int playerTwoRounds = 0;

            int lastScore = 0;
            
            bool player = true;
            
            while (true)
            {
                if (player)
                {
                    Console.WriteLine("\nPlayer One");
                    Console.WriteLine("Press Enter to roll your dice...");
                    Console.ReadKey();
                }
                else
                {
                    if (!twoPlayer)
                    {
                        Console.WriteLine("\nPlayer 2 (Computer) Turn");
                        Console.WriteLine("Rolling....");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer 2 Turn");
                        Console.WriteLine("Press enter to roll...");
                        Console.ReadKey();
                    }
                }

                List<int> rolledDie = RollFiveDie();

                for (int i = 0; i < rolledDie.Count; i++)
                {
                    Console.WriteLine($"Die {i + 1}: {rolledDie[i]}");
                }

                (int courseOfAction, int rollValueOfAction) = CourseOfAction(rolledDie);

                switch (courseOfAction)
                {
                    
                }

                playerOneScore += ((player) ? lastScore : 0);
                playerOneRounds += ((player) ? 1 : 0);
                playerTwoScore += ((!player) ? lastScore : 0);
                playerTwoRounds += ((!player) ? 1 : 0);
            }
        }
    }
}