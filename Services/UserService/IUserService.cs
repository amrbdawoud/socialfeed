using System;
using Microsoft.AspNetCore.Mvc;
using socialfeed.Models;

namespace socialfeed.Services.UserService;

public interface IUserService
{
    User? CreateUser(User user);
    User? EditUser(int id, User user);
    User? GetUser(int id);
    List<User> GetUsers();
}
