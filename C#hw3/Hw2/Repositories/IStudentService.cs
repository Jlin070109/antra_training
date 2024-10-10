using Hw2.DataModel;

namespace Hw2.Repositories;

public interface IStudentService : IPersonService
{
    void AddCourse(Course course);
    double CalculateGPA();
}