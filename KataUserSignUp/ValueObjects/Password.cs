namespace KataUserSignUp.ValueObjects;

public class Password
{
    public string value { get; }

    private Password(string password)
    {
        value = password;
    }

    public static Password create(string password)
    {
        if (password.Length < 8)
        {
            throw new ArgumentException();
        }

        return new Password(password);
    }
}


