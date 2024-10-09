namespace _02UnderstandingTypes;

public static class Hw1Program1
{
    // Method to display type information
    public static void DisplayTypeInformation()
    {
        Console.WriteLine("{0,-10} {1,10} {2,30} {3,30}", "Type", "Bytes", "Min Value", "Max Value");
        Console.WriteLine(new string('-', 85));

        DisplayTypeInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        DisplayTypeInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        DisplayTypeInfo("short", sizeof(short), short.MinValue, short.MaxValue);
        DisplayTypeInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        DisplayTypeInfo("int", sizeof(int), int.MinValue, int.MaxValue);
        DisplayTypeInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
        DisplayTypeInfo("long", sizeof(long), long.MinValue, long.MaxValue);
        DisplayTypeInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        DisplayTypeInfo("float", sizeof(float), float.MinValue, float.MaxValue);
        DisplayTypeInfo("double", sizeof(double), double.MinValue, double.MaxValue);
        DisplayTypeInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
    }

    public static void DisplayTypeInfo(string typeName, int size, object minValue, object maxValue)
    {
        Console.WriteLine("{0,-10} {1,10} {2,30} {3,30}", typeName, size, minValue, maxValue);
    }

    // Method to convert centuries
    public static void ConvertCenturies()
    {
        // Prompt the user to enter the number of centuries
        Console.Write("Enter the number of centuries: ");
        int centuries = int.Parse(Console.ReadLine());

        // Conversion factors
        int yearsInCentury = 100;
        double daysInYear = 365.2422; // Taking leap years into account
        int hoursInDay = 24;
        int minutesInHour = 60;
        int secondsInMinute = 60;
        int millisecondsInSecond = 1000;
        int microsecondsInMillisecond = 1000;
        int nanosecondsInMicrosecond = 1000;

        // Conversions
        int years = centuries * yearsInCentury;
        double days = years * daysInYear;
        double hours = days * hoursInDay;
        double minutes = hours * minutesInHour;
        double seconds = minutes * secondsInMinute;
        double milliseconds = seconds * millisecondsInSecond;
        double microseconds = milliseconds * microsecondsInMillisecond;
        double nanoseconds = microseconds * nanosecondsInMicrosecond;

        // Displaying the result
        Console.WriteLine($"{centuries} centuries = {years} years = {(long)days} days = {(long)hours} hours = {(long)minutes} minutes = {(long)seconds} seconds = {(long)milliseconds} milliseconds = {(long)microseconds} microseconds = {(decimal)nanoseconds} nanoseconds");
    }

    public static void FizzBuzz()
    {
        for (int i = 1; i < 100; i++)
        {
            if (i % 3 == 0 & i % 5 == 0)
            {
                Console.WriteLine($"{i} --> FizzBuzz");
            } else if (i % 5 == 0)
            {
                Console.WriteLine($"{i} --> Buzz");
            } else if (i % 3 == 0)
            {
                Console.WriteLine($"{i} --> Fizz");
            }
        }
    }

    public static void Test()
    {
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            if (i == 255)
            {
                Console.WriteLine("Warning: i is about to overflow!");
                break;
            }
            Console.WriteLine(i);
        }
        /*
        Create a console application and enter the preceding code. Run the console application
        and view the output. What happens?
            What code could you add (don’t change any of the preceding code) to warn us about the
        problem? see hw1_shortQA
        */
           
    }

    public static void GuessNumber()
    {
        // Generate a random number between 1 and 3
        int correctNumber = new Random().Next(3) + 1;

        // Ask the user to make a guess
        Console.WriteLine("Guess the number between 1 and 3:");

        // Read user input and convert to an integer
        string userInput = Console.ReadLine();
        int guessedNumber;
        
        // Check if input is a valid integer
        if (int.TryParse(userInput, out guessedNumber))
        {
            // Check if the guess is outside the valid range
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess is outside the valid range. Please guess between 1 and 3.");
            }
            else // correct range
            {
                // Check if the guess is correct, too low, or too high
                if (guessedNumber == correctNumber)
                {
                    Console.WriteLine("Correct! You guessed the number.");
                }
                else if (guessedNumber < correctNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else
                {
                    Console.WriteLine("Your guess is too high.");
                }
            }
            Console.WriteLine($"The correct answer is {correctNumber}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
        }
    }

    public static void Pyramid()
    {
        int height = 5; // Number of rows

        for (int i = 1; i <= height; i++)
        {
            // Print spaces
            for (int j = 1; j <= height - i; j++)
            {
                Console.Write(" ");
            }

            // Print stars
            for (int k = 1; k <= 2 * i - 1; k++)
            {
                Console.Write("*");
            }

            // Move to the next line
            Console.WriteLine();
        }
    }
    
    public static void CalculateDaysOldAndAnniversary(DateTime birthDate)
    {
        DateTime currentDate = DateTime.Now;
        TimeSpan ageSpan = currentDate - birthDate;
        int daysOld = ageSpan.Days;

        Console.WriteLine($"You are {daysOld} days old.");

        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversaryDate = currentDate.AddDays(daysToNextAnniversary);

        Console.WriteLine($"Your next 10,000-day anniversary will be on: {nextAnniversaryDate.ToShortDateString()}.");
    }
    
    
    public static void GreetBasedOnTime()
    {
        DateTime currentTime = DateTime.Now;
        int hour = currentTime.Hour;

        if (hour >= 5 && hour < 12)
        {
            Console.WriteLine("Good Morning");
        }

        if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good Afternoon");
        }

        if (hour >= 17 && hour < 21)
        {
            Console.WriteLine("Good Evening");
        }

        if (hour >= 21 || hour < 5)
        {
            Console.WriteLine("Good Night");
        }
    }
    
    public static void CountInIncrements()
    {
        for (int i = 1; i <= 4; i++) // Outer loop for increments (1 to 4)
        {
            for (int j = 0; j <= 24; j += i) // Inner loop with increments based on the outer loop variable
            {
                Console.Write(j);
                if (j < 24)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine();
        }
    }    
}