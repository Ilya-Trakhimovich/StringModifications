using System;

namespace StringModifications
{
    public static class UsersInterface
    {
        /// <summary>
        /// User's string
        /// </summary>
        private static string inputString;

        /// <summary>
        /// The method for enter a text
        /// </summary>
        /// <returns></returns>
        public static string EnterText()
        {
            bool isOperationCorrect = true;

            while (isOperationCorrect)
            {
                Console.WriteLine("Enter text:");

                inputString = Console.ReadLine();

                if (string.IsNullOrEmpty(inputString))
                {
                    Console.WriteLine("Dont use empty string or whitespaces. Try again");
                    isOperationCorrect = true;
                }
                else if (string.IsNullOrWhiteSpace(inputString))
                {
                    Console.WriteLine("Dont use empty string or whitespaces. Try again");
                    isOperationCorrect = true;
                }
                else
                {
                    isOperationCorrect = false;
                }

                Console.WriteLine("\n");
            }

            return inputString;
        }

        /// <summary>
        /// The method calls methods from TextModification by users pick.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="usersText"></param>
        public static void MakeChoice(int choice, string usersText)
        {
            bool flag = true;

            while (flag)
            {
                switch (choice)
                {
                    case 2:
                        TextModification.GetWordWitMaxCountOfNumbers(usersText);
                        flag = false;

                        break;
                    case 3:
                        TextModification.GetLongestWords(usersText);
                        flag = false;

                        break;
                    case 4:
                        //TextModification.ReplaceNumbersWithWords_2(usersText, out string textReplaceNumbersWithWords);
                        //Console.WriteLine($"{textReplaceNumbersWithWords}\n");
                        TextModification.ReplaceNumbersWithWords(usersText);
                        flag = false;

                        break;
                    case 5:
                        TextModification.DivideByPunctuation(usersText);
                        flag = false;

                        break;
                    case 6:
                        TextModification.GetSentencesWithoutComma(usersText);
                        flag = false;

                        break;
                    case 7:
                        TextModification.GetWordsWithTheSameBeginningAndEnds(usersText);
                        flag = false;
                        break;

                    case 8:
                        Environment.Exit(0);

                        break;
                    default:
                        Console.WriteLine("Wrong format! Try again.\n");
                        break;
                }
            }
        }
    }
}
