using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser;

public class LoginUserCommand : IRequest<ResultViewModel<string>>
{
    public LoginUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}