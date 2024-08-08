using KataUserSignUp.Models;

namespace KataUserSignUp.Repositories;

public class UserRepository
{
    private List<User> _users = new List<User>();

    public List<User> getAll() => _users;

    public void save(User user)
    {
        _users.Add(user);
    }
}