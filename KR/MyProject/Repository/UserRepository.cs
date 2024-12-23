using System.Collections.Generic;

public interface IUserRepository
{
    void Create(User user);
    User ReadById(int id);
    IEnumerable<User> ReadAll();
    void Update(User user);
    void Delete(int id);
}

