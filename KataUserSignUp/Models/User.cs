using KataUserSignUp.ValueObjects;

namespace KataUserSignUp.Models;

public record User(Guid id, string email, Password password)
{

}
