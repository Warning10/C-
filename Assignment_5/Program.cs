using System;

namespace Assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extension methods demo
            /*string sentence = "hello world from assignment";
            Console.WriteLine(sentence.ToTitleCase());
            Console.WriteLine(sentence.RemoveVowels());

            int? number = 25;
            Console.WriteLine(number.IsWithinRange(10, 30));*/

            // Reporting system demo
            ReportManager reportManager = new ReportManager();
          /*  IReport pdfReport = new PdfReport();
            IReport excelReport = new ExcelReport();
            IReport wordReport = new WordReport();

            reportManager.GenerateReport(pdfReport);
            reportManager.GenerateReport(excelReport);
            reportManager.GenerateReport(wordReport);*/

            // Permissions demo
/*            Permissions userPermissions = Permissions.Read | Permissions.Write;
            Console.WriteLine(userPermissions.HasPermission(Permissions.Read));
            Console.WriteLine(userPermissions.HasPermission(Permissions.Execute));*/

            // User interaction for extension methods
            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Convert string to title case");
                Console.WriteLine("2. Remove vowels from string");
                Console.WriteLine("3. Check if number is within range");
                Console.WriteLine("4. Generate report");
                Console.WriteLine("5. Check permissions");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a string: ");
                        string inputString = Console.ReadLine();
                        Console.WriteLine(inputString.ToTitleCase());
                        break;

                    case "2":
                        Console.Write("Enter a string: ");
                        inputString = Console.ReadLine();
                        Console.WriteLine(inputString.RemoveVowels());
                        break;

                    case "3":
                        Console.Write("Enter a number: ");
                        if (int.TryParse(Console.ReadLine(), out int inputNumber))
                        {
                            int? nullableNumber = inputNumber; // Convert to nullable int
                            Console.Write("Enter minimum range: ");
                            if (int.TryParse(Console.ReadLine(), out int minRange))
                            {
                                Console.Write("Enter maximum range: ");
                                if (int.TryParse(Console.ReadLine(), out int maxRange))
                                {
                                    Console.WriteLine(nullableNumber.IsWithinRange(minRange, maxRange));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for maximum range.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for minimum range.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for number.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Choose report type:");
                        Console.WriteLine("1. PDF");
                        Console.WriteLine("2. Excel");
                        Console.WriteLine("3. Word");
                        Console.Write("Enter your choice (1-3): ");
                        string reportChoice = Console.ReadLine();
                        IReport report = null;

                        switch (reportChoice)
                        {
                            case "1":
                                report = new PdfReport();
                                break;
                            case "2":
                                report = new ExcelReport();
                                break;
                            case "3":
                                report = new WordReport();
                                break;
                            default:
                                Console.WriteLine("Invalid report choice.");
                                break;
                        }

                        if (report != null)
                        {
                            reportManager.GenerateReport(report);
                        }
                        break;

                    case "5":
                        Console.WriteLine("Set user permissions (e.g., 3 for Read and Write):");
                        Console.WriteLine("1. None");
                        Console.WriteLine("2. Read");
                        Console.WriteLine("3. Write");
                        Console.WriteLine("4. Execute");
                        Console.Write("Enter permissions (bitwise OR values): ");
                        if (int.TryParse(Console.ReadLine(), out int permissionValue))
                        {
                            Permissions userPerms = (Permissions)permissionValue;
                            Console.WriteLine("Check for specific permission:");
                            Console.WriteLine("1. Read");
                            Console.WriteLine("2. Write");
                            Console.WriteLine("3. Execute");
                            Console.Write("Enter permission to check: ");
                            if (int.TryParse(Console.ReadLine(), out int checkPermissionValue))
                            {
                                Permissions checkPermission = (Permissions)checkPermissionValue;
                                Console.WriteLine(userPerms.HasPermission(checkPermission));
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for permission to check.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for permissions.");
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
