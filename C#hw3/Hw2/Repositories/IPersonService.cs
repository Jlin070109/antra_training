namespace Hw2.Repositories;

// Define interfaces for services
public interface IPersonService
{
    void CalculateAge();
    void AddAddress(string address);
    List<string> GetAddresses();
}