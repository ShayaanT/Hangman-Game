using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Hangman
{
    class Program
    {



        static void Main()
        {
            Console.WriteLine(@"                                                                     _______                                         
                                                                    |   |   |.---.-.-----.-----.--------.---.-.-----.
                                                                    |       ||  _  |     |  _  |        |  _  |     |
                                                                    |___|___||___._|__|__|___  |__|__|__|___._|__|__|
                                                                                         |_____|                     
                                                 
                                                 ");
            int selection1 = 0;
            var miliseconds = 1000;
            string word = "e";
            int selection2 = 0;
            string[] wordBank = { "astroid", "vegetables", "student", "theatre", "basketball", "dinosaur", "vehicle", "umbrella", "seahawk", "pineapple" };
            Random randomword = new Random();
            char unknownWord = '*';
            int randomHangmanWord = randomword.Next(0, wordBank.Length);
            int trys = 10;
            string hangmanword = wordBank[randomHangmanWord];
            int score = 0;
            Console.Write("                                                                                      ");
            for (int i = 0; i < hangmanword.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(unknownWord); //'*'
                Console.ResetColor();
            }
            Console.WriteLine();
            char[] input = new char[hangmanword.Length];

            for (int a = 0; a < hangmanword.Length; a++)
            {
                input[a] = unknownWord; //'*'
            }


            while (trys > 0)
            {
                Console.WriteLine("");
                Console.Write("                                                                                You have ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(trys);
                Console.ResetColor();
                Console.Write(" attempts");
                Console.WriteLine("");
                //Console.WriteLine("                                                                              You have " + trys + " attempts");
                Console.WriteLine("                                                                 1 - Guess a letter             2 - Guess the word");
                Console.Write("                                                         Please enter the number associated with the option of your choice: ");
                selection1 = Convert.ToInt32(Console.ReadLine());


                if (selection1 == 1)
                {
                    Console.Write("                                                                   Please enter a letter you think is in the word: ");

                    char userinput = char.Parse(Console.ReadLine());
                    userinput = char.ToLower(userinput);
                    bool answer = false;
                    Console.WriteLine("");
                    Console.Write("                                                                                      ");
                    for (int i = 0; i < hangmanword.Length; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (userinput == hangmanword[i])
                        {
                            input[i] = userinput;
                            answer = true;

                        }
                        else
                        {
                            answer = true;
                        }

                    }

                    if (answer == true)
                    {
                        trys--;
                    }
                    Console.WriteLine(input);
                    Thread.Sleep(miliseconds);
                    Console.ResetColor();

                    continue;


                }


                if (selection1 == 2)
                {
                    Console.Write("                                                                       Please enter what you think is the word: ");
                    word = Convert.ToString(Console.ReadLine());
                }



                if (word != hangmanword)
                {
                    Console.WriteLine("                                                                               Sorry, you are incorrect.");
                    trys = trys - 10;
                    Thread.Sleep(miliseconds);
                    continue;
                }

                if (word == hangmanword)
                {
                    score = trys * 1000;
                    Console.WriteLine();
                    Console.Write("                                                          Congratulations, you guessed the word right! Your score is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(score);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("                                                                               1 - Play again            2 - Exit");
                    Console.WriteLine();
                    Console.Write("                                                            Please enter the number associated with the option of your choice: ");
                    selection2 = Convert.ToInt32(Console.ReadLine());


                    if (selection2 == 1)
                    {

                        trys = 10;


                    }

                    if (selection2 == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("                                                                  Thank you, have a great day!");
                        Thread.Sleep(miliseconds);
                        return;

                    }


                    //break;
                }

            }
            Console.Write("                                                                               Game Over! You got ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0 ");
            Console.ResetColor();
            Console.Write("points");
            Console.WriteLine("");
            Console.Write("                                                                                 The word is ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(hangmanword);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
