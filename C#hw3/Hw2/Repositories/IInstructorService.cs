namespace Hw2.Repositories;

public interface IInstructorService : IPersonService
{
    decimal CalculateSalary();
    int CalculateExperience();
}