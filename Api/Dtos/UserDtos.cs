namespace Api.Dtos;

public record CreateUserDto(
    string Username,
    string Password,
    string PasswordConfirm
);

public record InactivateUserDto(
    int UserId
);