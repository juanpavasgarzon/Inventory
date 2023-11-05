namespace Domain.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }

    public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class CreateUserException : Exception
{
    public CreateUserException(string message) : base(message)
    {
    }

    public CreateUserException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class PasswordNotMatchException : Exception
{
    public PasswordNotMatchException(string message) : base(message)
    {
    }

    public PasswordNotMatchException(string message, Exception innerException) : base(message, innerException)
    {
    }
}