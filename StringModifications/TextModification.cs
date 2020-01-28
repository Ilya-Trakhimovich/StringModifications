using System;
using System.Collections.Generic;
using System.Linq;

namespace StringModifications
{
    public static class TextModification
    {
        /// <summary>
        /// The method shows interrogative and exclamatory sentences.
        /// </summary>
        /// <param name="text"></param>
        public static void DivideByPunctuation(string text)
        {
            List<string> strings = new List<string>(); // Saves interrogative and exclamatory sentences
            List<string> questionString = new List<string>(); // Saves interrogative sentences
            List<string> exclamationString = new List<string>(); // Saves exclamatory sentences
            int position = 0; // Saves position of '!' and '?'           

            while (position >= 0)
            {
                position = text.IndexOfAny(new char[] { '!', '?' }); // IndexOfAny returns -1 if char not found

                if (position >= 0)
                {
                    string modText = text.Substring(0, position + 1); //saves substring from start to '!' or '?'
                    int positionDot = 0;
                    int positionSemicolon = 0;

                    if (modText.Contains('.') || modText.Contains(';'))
                    {
                        while (positionDot >= 0) // Checks for a '.'
                        {
                            positionDot = modText.IndexOf('.');

                            if (positionDot >= 0)
                            {
                                modText = modText.Remove(0, positionDot + 1);
                            }
                        }

                        while (positionSemicolon >= 0) // Checks for a ';'
                        {
                            positionSemicolon = modText.IndexOf(';');

                            if (positionSemicolon >= 0)
                            {
                                modText = modText.Remove(0, positionSemicolon + 1);
                            }
                        }
                    }

                    // Substring(start, lenght)
                    strings.Add(modText);

                    // Remove(start, lenght)
                    // Remove(start, lenght)
                    //Remove(start, lenght)
                    text = text.Remove(0, position + 1); 
                }
            }

            foreach (var s in strings)
            {
                if (s.Length > 1 & s.Contains('?'))
                {
                    questionString.Add(s);
                }
                else if (s.Length > 1 & s.Contains('!'))
                {
                    exclamationString.Add(s);
                }
            }

            foreach (var q in questionString)
            {
                // ToDo: dgkdgnkngdgkhndgh
                Console.WriteLine(q);
            }

            Console.WriteLine("--------------------");

            foreach (var e in exclamationString)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// The method shows a word with max count of numbers. 
        /// </summary>
        /// <param name="text"></param>
        public static void GetWordWitMaxCountOfNumbers(string text)
        {
            string[] words = text.Split(new char[] { ' ', '!', '?', ';', ':', ',', '.', '\r', '\n' });
            List<string> wordsWithNumbers = new List<string>(); // Saves words with numbers
            int countOfDigit; // Saves count of digits
            int countOfDigitPrevious = 0; // Saves count of digits for previous word. Uses to compare words             
            int maxCount = 0; // Saves max count of numbers in the word
            List<string> wordsWithMaxNumbers; // Saves words with max count of numbers
            List<string> wordsWithMaxNumbers_2 = new List<string>();

            for (int i = 0; i < words.Length; i++) // Searches words with numbers
            {
                char[] chars = words[i].ToCharArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    if (char.IsNumber(chars[j]))
                    {
                        wordsWithNumbers.Add(words[i]);
                        break;
                    }
                }
            }            

            for (int i = 0; i < wordsWithNumbers.Count; i++) // Checks words for numbers
            {
                char[] chars = wordsWithNumbers[i].ToCharArray();
                countOfDigit = 0;

                for (int j = 0; j < chars.Length; j++) // Counts digits in the word
                {
                    if (char.IsNumber(chars[j]))
                    {
                        countOfDigit++;
                    }
                }

                if (countOfDigit > countOfDigitPrevious) // Compares words by max count of digits
                {
                    wordsWithMaxNumbers = new List<string>();
                    wordsWithMaxNumbers.Add(wordsWithNumbers[i]);
                    maxCount = countOfDigit;
                    wordsWithMaxNumbers_2 = wordsWithMaxNumbers;
                }
                else if (countOfDigit == countOfDigitPrevious)
                {
                    wordsWithMaxNumbers_2.Add(wordsWithNumbers[i]);
                }

                countOfDigitPrevious = countOfDigit;
            }

            for (int i = 0; i < wordsWithMaxNumbers_2.Count; i++) // Console output words with max count of numbers
            {
                char[] chars = wordsWithMaxNumbers_2[i].ToCharArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    if (char.IsNumber(chars[j]))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(chars[j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(chars[j]);
                    }
                }

                Console.Write($" - {maxCount} numbers");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// The method gets a list of the longest words in the text. Counts the number of repetitions
        /// </summary>
        /// <param name="text"></param>
        public static void GetLongestWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '!', '?', ';', ':', ',', '.', '\r', '\n', '(', ')', '}', '{', '\\', '/', '*' });
            string longestWord = words[0];
            List<string> listOfLongestWords = new List<string>();
            listOfLongestWords.Add(longestWord);

            for (int i = 1; i < words.Length; i++) // Searches the longest word and adds to list
            {
                if (longestWord.Length < words[i].Length)
                {
                    longestWord = words[i];
                    listOfLongestWords.Clear();
                    listOfLongestWords.Add(longestWord);
                }
                else if (longestWord.Length == words[i].Length)
                {
                    listOfLongestWords.Add(words[i]);
                }
            }

            var sortedList = listOfLongestWords.GroupBy(x => x);

            foreach (var i in sortedList)
            {
                Console.WriteLine($"{i.Key} - repeats {i.Count()} times");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// The method replcaes numbers with words.
        /// </summary>
        /// <param name="text"></param>
        public static void ReplaceNumbersWithWords(string text)
        {
            char[] characters = text.ToCharArray();

            for (int i = 0; i < characters.Length; i++) // Checks numbers in the array
            {
                if (!char.IsNumber(characters[i]))
                {
                    Console.Write(characters[i]);
                }
                else
                {
                    byte number = Convert.ToByte(characters[i].ToString());

                    switch (number)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("ONE");
                            Console.ResetColor();
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("TWO");
                            Console.ResetColor();
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("THREE");
                            Console.ResetColor();
                            break;

                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("FOUR");
                            Console.ResetColor();
                            break;

                        case 5:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("FIVE");
                            Console.ResetColor();
                            break;

                        case 6:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("SIX");
                            Console.ResetColor();
                            break;

                        case 7:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("SEVEN");
                            Console.ResetColor();
                            break;

                        case 8:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("EIGHT");
                            Console.ResetColor();
                            break;

                        case 9:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("NINE");
                            Console.ResetColor();
                            break;

                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("ZERO");
                            Console.ResetColor();
                            break;
                    }
                }
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// The method replcaes numbers with words. V 2.0 (Uses .Replace())
        /// </summary>
        /// <param name="text"></param>
        public static void ReplaceNumbersWithWords_2(string text, out string modText, string textHasntNums = "The text hasnt any numbers.")
        {
            string[] numbers = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
            modText = "";

            var condition = text.Contains('0') && !text.Contains('1') && !text.Contains('2') 
                && !text.Contains('3') && !text.Contains('4') && !text.Contains('5') 
                && !text.Contains('6') && !text.Contains('7') && !text.Contains('8') 
                && !text.Contains('9');

            if (!condition)
            {
                Console.WriteLine(textHasntNums);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    text = text.Replace(i.ToString(), numbers[i]);
                }

                modText = text;
            }           

            Console.WriteLine();
        }

        /// <summary>
        /// The method shows sentences without comma.
        /// </summary>
        /// <param name="text"></param>
        public static void GetSentencesWithoutComma(string text)
        {
            List<string> strings = new List<string>(); // Saves all sentences from text
            int position = 0; // Saves position of '!', '?', '.', ';'           

            while (position >= 0)
            {
                position = text.IndexOfAny(new char[] { '!', '?', '.', ';' }); // IndexOfAny returns -1 if char not found

                if (position >= 0)
                {
                    string modText = text.Substring(0, position + 1); // Saves substring from start to '!', '?', '.', ';'

                    if (!modText.Contains(',') & !string.IsNullOrWhiteSpace(modText))
                    {
                        strings.Add(modText); // Substring(start, lenght)
                    }

                    text = text.Remove(0, position + 1); // Remove(start, lenght)
                }
            }

            if (!string.IsNullOrEmpty(text) & !text.Contains(','))
            {
                strings.Add(text);
            }

            foreach (var i in strings)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// The method show words with the same beginnings and ends characters.
        /// </summary>
        /// <param name="text"></param>
        public static void GetWordsWithTheSameBeginningAndEnds(string text)
        {
            string[] words = text.Split(new[] { '?', '!', '.', ',', ':', ' ', '/', '\\', '(', ')', '*', '#', '^', ';', '\r', '\n' }); // Split text to strings
            List<string> listOfSameWords = new List<string>(); // Saves words with the same beginnings and ends characters

            for (int i = 0; i < words.Length; i++) // Finds words with the same beginnings and ends characters
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (!(string.IsNullOrEmpty(words[i]) | string.IsNullOrEmpty(words[j]))) // Checks empty words
                    {
                        if ((words[i].First() == words[j].First()) & (words[i].Last() == words[j].Last()))
                        {
                            if (!(listOfSameWords.Contains(words[i]))) // Excludes repetitions
                            {
                                listOfSameWords.Add(words[i]);
                            }
                            if (!listOfSameWords.Contains(words[j]))
                            {
                                listOfSameWords.Add(words[j]);
                            }
                        }
                    }
                }
            }

            foreach (var w in listOfSameWords)
            {
                if (w.Length > 1)
                    Console.WriteLine(w);
            }

            Console.WriteLine();
        }
    }
}
