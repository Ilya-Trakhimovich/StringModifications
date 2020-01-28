using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StringModifications
{
    public static class FileReader
    {
        /// <summary>
        /// The variable saves text from file.
        /// </summary>
        private static string textFromFile;

        /// <summary>
        /// The variable saves path to text file.
        /// </summary>
        private static string pathTextFile;

        /// <summary>
        /// The method returns text from text file.
        /// </summary>
        /// <returns></returns>
        public static string ReadTextFromFile()
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Enter path to the text file\n");

                pathTextFile = Console.ReadLine();

                if (!string.IsNullOrEmpty(pathTextFile) && !string.IsNullOrWhiteSpace(pathTextFile))
                {
                    FileInfo file = new FileInfo(pathTextFile);

                    if (file.Exists)
                    {
                        using (StreamReader sr = new StreamReader(pathTextFile))
                        {
                            textFromFile = sr.ReadToEnd();
                        }

                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("File not found. Try again.\n");
                        flag = true;
                    }
                }
                else
                {
                    Console.WriteLine("File not found. Try again.\n");
                }
            }

            return textFromFile;
        }
    }
}
