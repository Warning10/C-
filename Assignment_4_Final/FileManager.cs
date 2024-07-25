using System;
using System.IO;

namespace Assignment_4
{
    public class FileManager
    {
        private const string ListFileName = "list.txt";
        private const string FriendsFileName = "myfriends.txt";
        private const string SchoolDirectory = "school";

        public void CreateListFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ListFileName))
                {
                    Console.WriteLine("\nCreating list file...");

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write($"Enter name of friend {i + 1}: ");
                        string name = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(name) || !InputValidation.IsValidName(name))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a valid name.");
                            Console.ResetColor();
                            Console.Write($"Enter name of friend {i + 1}: ");
                            name = Console.ReadLine();
                        }
                        writer.WriteLine(name);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nList file created successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while creating the list file: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void CopyAndDeleteListFile()
        {
            try
            {
                if (!File.Exists(ListFileName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{ListFileName} does not exist. Please create the file first.");
                    Console.ResetColor();
                    CreateListFile();
                }
                else
                {
                    Console.WriteLine("\nCopying and deleting list file...");

                    File.Copy(ListFileName, FriendsFileName, true);
                    File.Delete(ListFileName);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("List file copied to myfriends.txt and deleted successfully.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while copying and deleting the list file: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void ReadAndDisplayFriendsFile()
        {
            try
            {
                if (File.Exists(FriendsFileName))
                {
                    Console.WriteLine("\nReading and displaying friends file...");

                    string[] friends = File.ReadAllLines(FriendsFileName);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Friends list:");
                    Console.WriteLine(new string('-', 30));
                    foreach (string friend in friends)
                    {
                        Console.WriteLine($"- {friend}");
                    }
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine($"Total number of friends: {friends.Length}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{FriendsFileName} does not exist.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while reading the friends file: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void MoveFriendsFileToSchoolDirectory()
        {
            try
            {
                Console.WriteLine("\nMoving friends file to school directory...");

                if (!Directory.Exists(SchoolDirectory))
                {
                    Directory.CreateDirectory(SchoolDirectory);
                }

                string destinationPath = Path.Combine(SchoolDirectory, FriendsFileName);
                File.Move(FriendsFileName, destinationPath);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Friends file moved to school directory successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while moving the friends file: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void DisplayAndDeleteSchoolDirectory()
        {
            try
            {
                Console.WriteLine("\nDisplaying and deleting school directory...");

                if (Directory.Exists(SchoolDirectory))
                {
                    string[] files = Directory.GetFiles(SchoolDirectory);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Files in {SchoolDirectory} directory:");
                    Console.WriteLine(new string('-', 30));
                    foreach (string file in files)
                    {
                        Console.WriteLine($"- {Path.GetFileName(file)}");
                    }
                    Console.WriteLine(new string('-', 30));

                    Directory.Delete(SchoolDirectory, true);
                    Console.WriteLine("School directory deleted successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{SchoolDirectory} directory does not exist.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while displaying or deleting the school directory: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
