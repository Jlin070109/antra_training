using System;
namespace _02UnderstandingTypes
{
    class Program
    {
        static void Main()
        {
            // Main menu
            Console.WriteLine("Input 1 or 2 to select hw1-1 or hw1-2:");
            int menuChoice = int.Parse(Console.ReadLine());
            if (menuChoice == 1)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Display memory size and range of numeric types.");
                Console.WriteLine("2. Convert centuries to years, days, hours, etc.");
                Console.WriteLine("3. FizzBuzz");
                Console.WriteLine("4. Test Error");
                Console.WriteLine("5. Guess number for once");
                Console.WriteLine("6. Build Pyramid");
                Console.WriteLine("7. CalculateDaysOldAndAnniversary");
                Console.WriteLine("8. GreetBasedOnTime");
                Console.WriteLine("9. CountInIncrements");
                Console.Write("Enter your choice (pick one from 1 to 9): ");
                int choice = int.Parse(Console.ReadLine());
    
                if (choice == 1)
                {
                    Hw1Program1.DisplayTypeInformation();
                }
                else if (choice == 2)
                {
                    Hw1Program1.ConvertCenturies();
                }
                else if (choice == 3)
                {
                    Hw1Program1.FizzBuzz();
                }
                else if (choice == 4)
                {
                    Hw1Program1.Test();
                }
                else if (choice == 5)
                {
                    Hw1Program1.GuessNumber();
                }
                else if (choice == 6)
                {
                    Hw1Program1.Pyramid();
                }
                else if (choice == 7)
                {
                    // demo birthday
                    Hw1Program1.CalculateDaysOldAndAnniversary(new DateTime(1996, 7, 15));
                }
                else if (choice == 8)
                {
                    Hw1Program1.GreetBasedOnTime();
                }
                else if (choice == 9)
                {
                    Hw1Program1.CountInIncrements();
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }

            if (menuChoice == 2)
            {   
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Copy Array");
                Console.WriteLine("2. Manage List");
                Console.WriteLine("3. Find Primes in Range");
                Console.WriteLine("4. Rotate and Sum Arrays");
                Console.WriteLine("5. Find Longest Sequence of Equal Elements");
                Console.WriteLine("6. Find Most Frequent Number");
                Console.WriteLine("7. Reverse String (Char Array)");
                Console.WriteLine("8. Reverse String (For Loop)");
                Console.WriteLine("9. Reverse Words in a Sentence");
                Console.WriteLine("10. Extract Palindromes");
                Console.WriteLine("11. Parse URL");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                
                if (choice == 1)
                {
                    Hw1Program2.CopyArray();
                }
                else if (choice == 2)
                {
                    Hw1Program2.ManageList();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter two numbers separated by a space:");
                    string input = Console.ReadLine();  // Get user input

                    // Split the input string by space
                    string[] parts = input.Split(' ');

                    // Parse the two values
                    int startNum = int.Parse(parts[0]);
                    int endNum = int.Parse(parts[1]);
                    int[] res = Hw1Program2.FindPrimesInRange(startNum, endNum);
                    Console.Write("Prime numbers:");
                    for (int i = 0; i <res.Length; i++)
                    {
                        Console.Write(res[i] + " "); 
                    }
                }
                else if (choice == 4)
                {
                    int[] arrayToRotate = helper();
                    Console.Write("Enter the number of rotations: ");
                    int k = int.Parse(Console.ReadLine());
                    Hw1Program2.RotateAndSumArrays(arrayToRotate, k);
                }
                else if (choice == 5)
                {
                    int[] sequenceArray = helper();
                    Hw1Program2.FindLongestSequence(sequenceArray);
                }
                else if (choice == 6)
                {
                    int[] sequenceArray = helper();
                    Hw1Program2.FindMostFrequent(sequenceArray);
                }
                else if (choice == 7)
                {
                    Console.Write("Enter the string input: ");
                    string input = Console.ReadLine();
                    Hw1Program2.ReverseStringCharArray(input);
                }
                else if (choice == 8)
                {
                    Console.Write("Enter the string input: ");
                    string input = Console.ReadLine();
                    Hw1Program2.ReverseStringForLoop(input);
                }
                else if (choice == 9)
                {
                    Console.Write("Enter the string input: ");
                    string input = Console.ReadLine();
                    string res = Hw1Program2.ReverseWordsInSentence(input);
                    Console.Write(res);
                }
                else if (choice == 10)
                {
                    Console.Write("Enter the string input: ");
                    string input = Console.ReadLine();
                    Hw1Program2.ExtractPalindromes(input);
                }
                else if (choice == 11)
                {
                    Console.Write("Enter the string input: ");
                    string input = Console.ReadLine();
                    Hw1Program2.ParseUrl(input);
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }    
            }
            
        }

        public static int[] helper()
        {
            Console.WriteLine("Enter the array of integers (space-separated): ");
            string input = Console.ReadLine();               
            string[] stringArray = input.Split(' ');         
            int[] arrayTarget = new int[stringArray.Length]; 
            for (int i = 0; i < stringArray.Length; i++)
            {
                arrayTarget[i] = int.Parse(stringArray[i]); // Convert each string to an integer
            }
            return arrayTarget;
        }

    }
}
