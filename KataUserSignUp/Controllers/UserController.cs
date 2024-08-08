using KataUserSignUp.Models;
using KataUserSignUp.Repositories;
using KataUserSignUp.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace KataUserSignUp.Controllers;

[ApiController]
[Route("[controller]")]
public partial class UserController : ControllerBase
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
    public IActionResult Post(UserRequest request)
    {
        User user;

        try
        {
            user = new User(Guid.NewGuid(), request.email, Password.create(request.password));
        }
        catch(ArgumentException){
            return BadRequest();
        } 

        _userRepository.save(user);

        _logger.LogInformation("Usuario nuevo creado {id} con este email {email}", user.id, user.email);

        return Ok(user.id);
    }

}
