namespace Hw2;

public static class ReverseGeneratedNumbers
{
    // Method to generate an array with a given length
    public static int[] GenerateNumbers(int length) {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++) {
            numbers[i] = i + 1; // Filling array with values 1 to 10
        }
        return numbers;
    }

    // Method to reverse an array
    public static void Reverse(int[] arr) {
        int temp;
        for (int i = 0; i < arr.Length / 2; i++) {
            temp = arr[i];
            arr[i] = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = temp;
        }
    }

    // Method to print the array
    public static void PrintNumbers(int[] arr) {
        foreach (int num in arr) {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}