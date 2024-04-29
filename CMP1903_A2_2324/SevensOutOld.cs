using System;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    public class SevensOutOld : Game
    {
        private Die _dieOne = new Die();
        private Die _dieTwo = new Die();
        
        public override (int, int, int) PvE()
        {
            int computerTotal = 0;
            int playerTotal = 0;
            int lastTotal = 0;
            bool playerOrComputer = false;

            while (true)
            {
                playerOrComputer = !playerOrComputer;
                

                if (playerOrComputer)
                {
                    Console.WriteLine("\nPlayer 1 Turn");
                    Console.WriteLine("Press enter to roll...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nComputers Turn");
                    Console.WriteLine("Rolling....");
                    Thread.Sleep(1000);
                }
                
                int rollOne = _dieOne.Roll();
                int rollTwo = _dieTwo.Roll();
                lastTotal = ((rollOne == rollTwo) ? (rollOne + rollTwo) * 2 : rollOne + rollTwo);
                
                Console.WriteLine($"Roll One: {rollOne}");
                Thread.Sleep(1000);
                Console.WriteLine($"Roll Two: {rollTwo}");
                Thread.Sleep(500);
                
                if (rollOne == rollTwo)
                {
                    Console.WriteLine("Double Detected! Doubling Total.");
                }
                
                Console.WriteLine($"Total: {lastTotal}");
                
                if (lastTotal == 7)
                {
                    break;
                }

                if (playerOrComputer)
                {
                    playerTotal += lastTotal;
                }
                else
                {
                    computerTotal += lastTotal;
                    
                }
                
                Console.WriteLine($"New Total: {((playerOrComputer) ? playerTotal : computerTotal)}");
            }
            
            Console.WriteLine("Seven Achieved!");
            Console.WriteLine(((playerOrComputer) ? "Player Wins" : "Computer Wins"));

            return (playerTotal, computerTotal, lastTotal);
        }
        
        public override (int, int) PvP()
        {
            return (0, 0);
        }
    }
}