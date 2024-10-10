namespace Hw2;

public class Fibon
{
    // Recursive Fibonacci method
    public static int Fibonacci(int n) {
        // Base case: first and second numbers are 1
        if (n == 1 || n == 2) {
            return 1; 
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2); // Recursive case
    }
}