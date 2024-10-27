namespace ApplicationCore.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> GetUserById(int id);
    Task<User> AddUser(User user);
    // Add more user-related repository methods
}