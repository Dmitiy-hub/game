using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        private static void printGallows(int wrong)
        {
            switch (wrong)
            {
                case 7:
                    Console.WriteLine("\n    ----+");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 6:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 5:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 4:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("   O    |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 3:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("   O    |");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 2:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("  \\O    |");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 1:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("  \\O/   |");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
                case 0:
                    Console.WriteLine("\n   +----+");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("  \\O/   |");
                    Console.WriteLine("   |    |");
                    Console.WriteLine("  / \\   |");
                    Console.WriteLine("        |");
                    Console.WriteLine("   ======");
                    break;
            }
        }

        private static int printWord(List<char> guessedLetters, string randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (guessedLetters.Contains(randomWord[i]))
                {
                    Console.Write(randomWord[i] + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write("  ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(string randomWord)
        {
            for (int i = 0; i < randomWord.Length; i++)
            {              
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        private static void rate(int wrong, string word)
        {
            if (wrong < 1)
            {
                Console.WriteLine("\nYou lost! This was the word: {0} \nThanks for playing :)\n", word);
            }
            else
            {
                Console.WriteLine("\nYou win! Thanks for playing :)");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" ---------------------------------------------");
            Console.WriteLine("|             Welcome to the game :)          |");
            Console.WriteLine(" ---------------------------------------------");

            Random random = new Random();
            string[] wordDictionary = new string[48] {"mister","tank","professional","Minecraft","laptop","mouse","school","friends","phone","adapter",
                "notebook","pen","kalash","book","drawing","diary","clock","headphones","eraser","ruler","pirate","textbook","teacher","team","wire","gift",
                "rainbow","stadium","cake","chamomile","fishing","felt","hare","moon","park","paper","pike","stork","treasure" ,"writer","math","account",
                "menu","success","table","bicycle","pyramid","number"};
            //new string[53] { "містер","танк","професіонал","Майнкрафт","слово","ноутбук","миша","школа","друзі","телефон","адаптер","зошит","ручка","калач","книга",
            //"креслення","щоденник","годинник","навушники","дріт","ластик","лінійка","циркуль","підручник","пірат","вчителька","команда","автобус","подарунок","райдуга","стадіон",
            //"цуценя","місяць","скарб","заєць","торт","фломайстер","рибалка","парк","ромашка","подорож","папір","лелека","щука","письменник","математика","рахунок","меню",
            //"успіх","стіл","велосипед","піраміда","число"};
            int index = random.Next(0, wordDictionary.Length);
            string randomWord = wordDictionary[index];

            printLines(randomWord);

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 7;
            List<char> currentLetterGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong > 0 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.WriteLine("\nUsed letters: ");
                for (int i = 0; i < currentLetterGuessed.Count; i++)
                {
                    Console.Write(currentLetterGuessed[i] + ", ");
                }

                Console.Write("\nEnter your letter: ");
                char letterGuessed = Convert.ToChar(Console.ReadLine());

                if (currentLetterGuessed.Contains(letterGuessed))
                {
                    Console.WriteLine("\n--------------------------------------");
                    Console.Write("\nYou have already used this letter!");
                    Console.WriteLine("\nLives left: {0}", amountOfTimesWrong);
                    printGallows(amountOfTimesWrong);

                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    if (right)
                    {
                        Console.WriteLine("\n--------------------------------------");
                        Console.WriteLine("\nLives left: {0}", amountOfTimesWrong);
                        printGallows(amountOfTimesWrong);
                        currentLetterGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLetterGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        Console.WriteLine("\n--------------------------------------");
                        Console.WriteLine("\nLives left: {0}", amountOfTimesWrong);
                        amountOfTimesWrong--;
                        currentLetterGuessed.Add(letterGuessed);
                        printGallows(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLetterGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\nLives left: {0}", amountOfTimesWrong);
            rate(amountOfTimesWrong, randomWord);

            Console.ReadKey();
        }
    }
}
