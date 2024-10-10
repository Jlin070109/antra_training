using Hw2.Repositories;

namespace Hw2.DataModel;

// Course class (Abstraction)
public class Course: ICourseService
{
    public string CourseName { get; set; }
    public string Grade { get; set; }  // Grade from A to F

    public Course(string courseName, string grade)
    {
        CourseName = courseName;
        Grade = grade;
    }

    // Convert grade to points
    public double GradeToPoint()
    {
        switch (Grade.ToUpper())
        {
            case "A": return 4.0;
            case "B": return 3.0;
            case "C": return 2.0;
            case "D": return 1.0;
            case "F": return 0.0;
            default: throw new ArgumentException("Invalid grade.");
        }
    }
}