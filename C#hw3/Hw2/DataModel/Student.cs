using Hw2.Repositories;

namespace Hw2.DataModel;

// Derived class - Student (Abstraction, Inheritance, Encapsulation)
public class Student : Person, IStudentService
{
    private List<Course> Courses = new List<Course>();
    private IStudentService _studentServiceImplementation;

    public Student(string name, DateTime birthDate) : base(name, birthDate)
    {
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
    }

    // Calculate GPA based on grades in courses
    public double CalculateGPA()
    {
        double totalPoints = 0;
        int totalCourses = Courses.Count;

        foreach (var course in Courses)
        {
            totalPoints += course.GradeToPoint();
        }

        return totalCourses > 0 ? totalPoints / totalCourses : 0;
    }

    public override decimal CalculateSalary()
    {
        // Students don't have a salary
        return 0;
    }
}