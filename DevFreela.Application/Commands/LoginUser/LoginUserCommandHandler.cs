using System.ComponentModel.DataAnnotations;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<string>>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _repository = userRepository;
        _authService = authService;
    }

    public async Task<ResultViewModel<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passworkHash = _authService.ComputeHash(request.Password);

        var user = await _repository.LoginByEmailAndPasswordAsync(request.Email, request.Password);

        if(user is null) return ResultViewModel<string>.Error("Email ou senha inválidos");

        var token = _authService.GenerateToken(user.Email, user.Role);

        return ResultViewModel<string>.Success(token);
    }
}