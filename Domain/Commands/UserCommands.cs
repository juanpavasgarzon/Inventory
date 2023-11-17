namespace Domain.Commands;

public record CreateUserCommand(
    string Username,
    string Password,
    string PasswordConfirm
);