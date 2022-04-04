using System;

namespace LessonHW17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuessNumberGame game = new GuessNumberGame(100,0,5,guessingPlayer:GuessNumberGame.GuessingPlayer.Machine); //GuessingPlayer.Human
            game.Start();
            

            Console.ReadLine();
        }
    }
}
