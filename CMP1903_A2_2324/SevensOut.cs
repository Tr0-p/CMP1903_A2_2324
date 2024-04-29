﻿using System;
using System.Threading;

namespace CMP1903_A2_2324
{
    public class SevensOut : Game
    {
        private Die _dieOne = new Die();
        private Die _dieTwo = new Die();

        public override (int, int, int) PvE()
        {
            int computerTotal = 0;
            int playerTotal = 0;
            int lastTotal = 0;
            bool playerOrComputer = true;

            while (true)
            {
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
                    Console.WriteLine("Seven Detected!");

                    if (!playerOrComputer)
                    {
                        break;
                    }

                    playerOrComputer = false;
                    continue;
                }

                playerTotal += ((playerOrComputer) ? lastTotal : 0);
                computerTotal += ((playerOrComputer) ? 0: lastTotal);
                
                Console.WriteLine($"Combined Total: {((playerOrComputer) ? playerTotal : computerTotal)}");
            }
            
            Console.WriteLine(((playerTotal < computerTotal) ? "\nPlayer Wins" : "\nComputer Wins"));
            Console.WriteLine($"Player Total: {playerTotal}");
            Console.WriteLine($"Computer Total: {computerTotal}");
            
            return (playerTotal, computerTotal, lastTotal);
        }

        public override (int, int) PvP()
        {
            return (0, 0);
        }
    }
}
