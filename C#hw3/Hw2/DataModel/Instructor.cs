using Hw2.Repositories;

namespace Hw2.DataModel;

// Derived class - Instructor (Abstraction, Inheritance, Polymorphism)
public class Instructor : Person, IInstructorService
{
    public DateTime JoinDate { get; set; }
    public decimal BaseSalary { get; set; }
    public Department Department { get; set; }
    private decimal ExperienceBonus { get; set; } = 500m;  // Bonus per year of experience

    public Instructor(string name, DateTime birthDate, DateTime joinDate, decimal baseSalary) : base(name, birthDate)
    {
        JoinDate = joinDate;
        BaseSalary = baseSalary >= 0 ? baseSalary : throw new ArgumentException("Salary cannot be negative.");
    }

    public int CalculateExperience()
    {
        return DateTime.Now.Year - JoinDate.Year;
    }

    // Polymorphism: Salary calculation with added bonus for experience
    public override decimal CalculateSalary()
    {
        int yearsOfExperience = CalculateExperience();
        return BaseSalary + (ExperienceBonus * yearsOfExperience);
    }
}