using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _02UnderstandingTypes;

public static class Hw1Program2
{
// 1. Copying an Array
    public static void CopyArray()
    {
        int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] copiedArray = new int[originalArray.Length];

        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }

        Console.WriteLine("Original Array: " + string.Join(", ", originalArray));
        Console.WriteLine("Copied Array: " + string.Join(", ", copiedArray));
    }

    // 2. Manage a list of elements (To-do list or grocery list management)
    public static void ManageList()
    {
        List<string> list = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, exit, or -- to clear):");
            string input = Console.ReadLine();
            if (input.StartsWith("+"))
            {
                list.Add(input.Substring(2).Trim());
            }
            else if (input.StartsWith("-"))
            {
                list.Remove(input.Substring(2).Trim());
            }
            else if (input == "--")
            {
                list.Clear();
            } 
            else if (input == "exit")
            {
                Console.WriteLine("Final list: " + string.Join(", ", list));
                break;
            }

            Console.WriteLine("Current list: " + string.Join(", ", list));
        }
    }

    // 3. Find primes in range
    public static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    // 4. Rotate and sum arrays
    public static void RotateAndSumArrays(int[] arr, int k)
    {
        int n = arr.Length;
        int[] sum = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                rotatedArray[(i + r) % n] = arr[i];
            }

            for (int i = 0; i < n; i++)
            {
                sum[i] += rotatedArray[i];
            }

            Console.WriteLine($"Rotated {r}: " + string.Join(", ", rotatedArray));
        }

        Console.WriteLine("Sum: " + string.Join(", ", sum));
    }

    // 5. Find the longest sequence of equal elements
    public static void FindLongestSequence(int[] arr)
    {
        int bestLength = 1;
        int currentLength = 1;
        int bestElement = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestElement = arr[i];
            }
        }

        Console.WriteLine("Longest sequence: " + string.Join(" ", Enumerable.Repeat(bestElement, bestLength)));
    }

    // 6. Find the most frequent number
    public static void FindMostFrequent(int[] arr)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (var number in arr)
        {
            if (!frequency.ContainsKey(number))
            {
                frequency[number] = 0;
            }
            frequency[number]++;
        }

        int mostFrequent = frequency.OrderByDescending(x => x.Value).ThenBy(x => Array.IndexOf(arr, x.Key)).First().Key;
        Console.WriteLine("Most frequent number: " + mostFrequent);
    }
    //7. Reverse String (Char Array)
    // String Practice 1: Reverse string by converting to char array
    public static void ReverseStringCharArray(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine(new string(charArray));
    }
    //8. Reverse String (For Loop)
    // String Practice 1: Reverse string by iterating backwards
    public static void ReverseStringForLoop(string input)
    {
        for (int i = input.Length - 1; i >= 0; i--)
        {
            Console.Write(input[i]);
        }
        Console.WriteLine();
    }
    //9. Reverse Words in a Sentence
    // String Practice 2: Reverse words in a sentence without changing punctuation and spaces
    // Helper method to extract palindromes from a text
    // Method to reverse words in a sentence while preserving punctuation
    public static string ReverseWordsInSentence(string sentence)
    {
        // Define the separators using a regular expression
        string pattern = @"[\s\.\,\:\;\=\(\)\&\[\]""'\\/!\?]+";

        // Split the sentence into words and separators
        string[] words = Regex.Split(sentence, pattern);
        string[] separators = Regex.Matches(sentence, pattern)
            .Cast<Match>()
            .Select(m => m.Value)
            .ToArray();

        // Filter out empty words (can happen due to splitting)
        List<string> nonEmptyWords = new List<string>();
        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                nonEmptyWords.Add(word);
            }
        }

        // Reverse the words
        nonEmptyWords.Reverse();

        // Rebuild the sentence by combining reversed words with the original separators
        List<string> result = new List<string>();
        int wordIndex = 0, separatorIndex = 0;

        // Combine words and separators while keeping their positions intact
        while (wordIndex < nonEmptyWords.Count || separatorIndex < separators.Length)
        {
            if (wordIndex < nonEmptyWords.Count)
            {
                result.Add(nonEmptyWords[wordIndex++]);
            }
            if (separatorIndex < separators.Length)
            {
                result.Add(separators[separatorIndex++]);
            }
        }

        // Join the result into a single string and return it
        return string.Join("", result);
    }
    
    //10. Extract Palindromes
    // String Practice 3: Extract and sort palindromes
    public static List<string> ExtractPalindromes(string text)
    {
        // Use regex to split the text into words, considering only letters (ignoring punctuation)
        string[] words = Regex.Split(text, @"\W+");

        // Create a HashSet to store unique palindromes (ignores duplicates)
        HashSet<string> uniquePalindromes = new HashSet<string>();

        foreach (string word in words)
        {
            if (IsPalindrome(word) && word.Length > 1) // Check if it's a palindrome and longer than 1
            {
                uniquePalindromes.Add(word); // Add the palindrome to the set
            }
        }

        // Return the palindromes as a sorted list
        List<string> sortedPalindromes = uniquePalindromes.ToList();
        sortedPalindromes.Sort();
        return sortedPalindromes;

    }

    // Helper method to check if a word is a palindrome
    static bool IsPalindrome(string word)
    {
        if (string.IsNullOrEmpty(word)) return false;

        int length = word.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (char.ToLower(word[i]) != char.ToLower(word[length - i - 1]))
            {
                return false;
            }
        }
        return true;
    }
    //11. Parse URL
    // String Practice 4: Parse URL
    // Method to parse the URL and extract protocol, server, and resource
    public static void ParseUrl(string url)
    {
        string protocol = "";
        string server = "";
        string resource = "";

        // Find the protocol part if present
        int protocolEndIndex = url.IndexOf("://");
        if (protocolEndIndex != -1)
        {
            protocol = url.Substring(0, protocolEndIndex); // Extract protocol
            url = url.Substring(protocolEndIndex + 3);     // Remove protocol part from URL
        }

        // Find the server part (everything up to the first '/')
        int serverEndIndex = url.IndexOf('/');
        if (serverEndIndex != -1)
        {
            server = url.Substring(0, serverEndIndex);     // Extract server
            resource = url.Substring(serverEndIndex + 1);  // Extract resource
        }
        else
        {
            server = url;  // If no resource part, the rest of the URL is the server
        }

        // Print the extracted parts
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }   
}