using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace DevFreela.Application.Commands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public User ToEntity()
        => new(FullName, Email, BirthDate);
}