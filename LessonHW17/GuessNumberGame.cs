using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonHW17
{
    public class GuessNumberGame
    {
        private readonly int max;
        private readonly int min;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;

        public enum GuessingPlayer
        {
               Human,
               Machine
        }

        public GuessNumberGame(int max, int min, int maxTries,GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.min = min;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }

        public GuessNumberGame()
        {
        }

        public void Start()
        {
            if (guessingPlayer == GuessingPlayer.Human)
            {
                HumanGuesses();
            }
            else
            {
                MachineGuesses();
            }


        }

        private void MachineGuesses()
        {
            Console.WriteLine("Enter a number that`s going to be guessed by a computer.");
            int guessedNumber = -1;
            while (guessedNumber == -1)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                if (parsedNumber >= 0 && parsedNumber <=  this.max)
                {
                    guessedNumber = parsedNumber;
                }
            }

            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < maxTries)
            {
                lastGuess = (min + max) / 2;
                Console.WriteLine($"Did you guessed this number - {lastGuess}?");
                Console.WriteLine("If yes, enter - 'y', if number greater, enter - 'g', if number less, enter - 'l'");
                string answer = Console.ReadLine();
               if (answer == "y")
               {
                    Console.WriteLine("Super! I guessed your number!");
                    break;
               }

               if (answer == "g")
               {
                    Console.WriteLine("Oh, okey...");
                    min = lastGuess;
               }

               if (answer == "l")
               {
                    Console.WriteLine("Oh, okey...");
                    max = lastGuess;
               }
                      
                   
                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Don`t cheat, man!");
                }
                tries++;
                if (tries == maxTries)
                {
                    Console.WriteLine("No tries anymore :( I lost! ");
                }

            }

        }

        private void HumanGuesses()
        {
           Random rnd = new Random();
           int guessednumber = rnd.Next(min,max);
            int lastGuess = -1;
            int tries = 0;
            while (lastGuess != guessednumber && tries < maxTries)
            {
                Console.WriteLine("Guess the number!");
                lastGuess = int.Parse(Console.ReadLine());

                if (lastGuess == guessednumber)
                {
                    Console.WriteLine("Congrats! You guessed the number!");
                    break;
                }
                else if (lastGuess < guessednumber)
                {
                    Console.WriteLine("My number is greater!");
                }
                else
                {
                    Console.WriteLine("My number is less!");
                }
                tries++;
                if (tries == maxTries)
                {
                    Console.WriteLine("You lost!");
                }
            }

        }
    }
}
