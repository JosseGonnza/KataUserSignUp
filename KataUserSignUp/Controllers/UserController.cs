using Microsoft.AspNetCore.Mvc;

namespace KataUserSignUp.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly UserRepository _userRepository;

    public UserController(ILogger<UserController> logger, UserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    [HttpGet]
    public List<User> Get()
    {
        return _userRepository.getAll();
    }

    [HttpPost]
    public Guid Post(UserRequest request)
    {
        User user = new User(Guid.NewGuid(), request.email, request.password);
        _userRepository.save(user);

        _logger.LogInformation("Usuario nuevo creado {id} con este email {email}", user.id, user.email);

        return user.id;
    }
}

public record User(Guid id, string email, string password);

public record UserRequest(string email, string password);

public class UserRepository
{
    private List<User> _users = new List<User>();

    public List<User> getAll() => _users;

    internal void save(User user)
    {
        _users.Add(user);
    }
}