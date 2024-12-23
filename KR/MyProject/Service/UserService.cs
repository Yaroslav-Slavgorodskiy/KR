using System.Collections.Generic;

public interface IUserService
{
    void RegisterUser(string username, string password); 
    User Login(string username, string password); 
    IEnumerable<User> GetAllUsers(); 
    void AddBalance(User user, decimal amount); 
    User? GetUserByCredentials(string username, string password); 
     User ReadAccountById(int id); 
}
