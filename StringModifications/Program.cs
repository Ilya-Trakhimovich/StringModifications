using System;

namespace StringModifications
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            string usersText;   //User's text
            string menuText = $"1 - Enter text;\n" +
                            $"2 - Find words containing the maximum number of digits;\n" +
                            $"3 - Find the longest word and determine how many times it appears in the text;\n" +
                            $"4 - Replace numbers with words;\n" +
                            $"5 - Display interrogative and exclamatory sentences;\n" +
                            $"6 - Display sentences without commas;\n" +
                            $"7 - Find words with the same beginnig and ends characters;\n" +
                            $"8 - Exit;";

            while (flag)
            {
                Console.WriteLine(
               "1 - Enter text manually;\n" +
               "2 - Get text from file.");

                bool isChoice = int.TryParse(Console.ReadLine(), out int choice_1);

                if (isChoice)
                {
                    switch (choice_1)
                    {
                        case 1:
                            bool flag_2 = true;
                            usersText = UsersInterface.EnterText();

                                while (flag_2)
                                {
                                    Console.WriteLine(menuText);
                                    
                                    bool isCorrectChoice = int.TryParse(Console.ReadLine(), out int choice_2);
    
                                    if (choice_2 == 1)
                                    {
                                        flag_2 = false;
                                        break;
                                    }

                                    if (isCorrectChoice)
                                    {
                                        UsersInterface.MakeChoice(choice_2, usersText);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong format! Try again.\n");
                                    }
                                }
                            
                            break;

                        case 2:
                            usersText = FileReader.ReadTextFromFile();
                            bool flag_3 = true;

                            Console.WriteLine($"{usersText}\n");

                                while (flag_3)
                                {
                                    Console.WriteLine(menuText);

                                    bool isCorrectChoice_2 = int.TryParse(Console.ReadLine(), out int choice_3);
                                 
                                    if (choice_3 == 1)
                                    {
                                        break;
                                    }

                                    if (isCorrectChoice_2)
                                    {
                                        UsersInterface.MakeChoice(choice_3, usersText);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong format! Try again.\n");
                                    }
                                }

                            break;

                        default:
                            Console.WriteLine("Wrong format. Try again\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Try again!\n");
                }
            }
        }
    }
}