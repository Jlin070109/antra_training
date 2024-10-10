using System;
using Hw2.DataModel;

//question 1 reverse generated numbers
int[] numbers = Hw2.ReverseGeneratedNumbers.GenerateNumbers(10); // Generate an array of length 10
Hw2.ReverseGeneratedNumbers.Reverse(numbers);                    // Reverse the array
Hw2.ReverseGeneratedNumbers.PrintNumbers(numbers);               // Print the reversed array

//question 2 first 10 fibonacci sequence
for (int i = 1; i <= 10; i++)
{
    Console.Write(Hw2.Fibon.Fibonacci(i) + " ");
}
// question 3
// Create Instructor
Instructor instructor = new Instructor("John Smith", new DateTime(1980, 5, 15), new DateTime(2010, 9, 1), 50000);
instructor.AddAddress("123 Main St.");
instructor.CalculateAge();
Console.WriteLine($"Instructor Salary: {instructor.CalculateSalary()}");

// Create Student
Student student = new Student("Alice Johnson", new DateTime(2002, 3, 25));
student.AddCourse(new Course("Math", "A"));
student.AddCourse(new Course("Science", "B"));
Console.WriteLine($"Student GPA: {student.CalculateGPA()}");

// Create Department
Department department = new Department("Computer Science", 1000000, DateTime.Now, DateTime.Now.AddYears(1));
department.Head = instructor;
department.AddCourse(new Course("Intro to Programming", "A"));
Console.WriteLine($"Department Head: {department.Head.Name}");

// question 4
// Creating a Color
Color redColor = new Color(255, 0, 0);
Console.WriteLine("Grayscale value of Red: " + redColor.GetGrayscale());

// Creating a Ball
Ball ball = new Ball(5, redColor);

// Throw the ball a few times
ball.Throw();
ball.Throw();

// Pop the ball and try to throw it again
ball.Pop();
ball.Throw();

// Print the number of throws
Console.WriteLine("Number of throws: " + ball.GetThrowCount());