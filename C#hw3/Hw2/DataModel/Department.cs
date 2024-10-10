using Hw2.Repositories;

namespace Hw2.DataModel;

// Department class (Abstraction)
public class Department: IDepartmentService
{
    public string DepartmentName { get; set; }
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> CoursesOffered { get; set; }

    public Department(string departmentName, decimal budget, DateTime startDate, DateTime endDate)
    {
        DepartmentName = departmentName;
        Budget = budget;
        StartDate = startDate;
        EndDate = endDate;
        CoursesOffered = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        CoursesOffered.Add(course);
    }
}