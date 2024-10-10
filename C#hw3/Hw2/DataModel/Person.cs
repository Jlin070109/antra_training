using Hw2.Repositories;

namespace Hw2.DataModel;

// Base class - Person (Abstraction, Inheritance)
public abstract class Person : IPersonService
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    private List<string> Addresses = new List<string>();

    public Person(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }

    // Abstraction of Age calculation
    public void CalculateAge()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
            age--;
        Console.WriteLine($"{Name} is {age} years old.");
    }

    public void AddAddress(string address)
    {
        Addresses.Add(address);
    }

    public List<string> GetAddresses()
    {
        return Addresses;
    }

    // Abstract method for salary calculation (Polymorphism)
    public abstract decimal CalculateSalary();
}