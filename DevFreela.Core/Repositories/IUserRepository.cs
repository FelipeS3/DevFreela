﻿using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserById(int id);
    Task<User> LoginByEmailAndPasswordAsync(string email, string passwordHash);
    Task<int> AddUser(User user);
    Task<int> PostUserSkills(UserSkill skills);
    Task<User?> GetById(int id);

}