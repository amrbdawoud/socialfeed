using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using socialfeed.Data;
using socialfeed.Models;

namespace socialfeed.Services.UserService;

public class UserService : IUserService
{
    private readonly SocialFeedContext _context;
    public UserService(SocialFeedContext context)
    {
        _context = context;
    }
    public User? CreateUser(User user)
    {
        try
        {
        _context.Users.Add(user);
        _context.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return null;
        }
        return user;
    }

    public User? GetUser(int id)
    {
        var user = _context.Users.Where(u => u.Id == id && !u.IsDeleted).FirstOrDefault(); // Note: should i use async?
        if (user == null){
            return null;
        }
        return user;
    }

    public List<User> GetUsers()
    {
        List<User> users = _context.Users.Where(u => !u.IsDeleted).ToList();
        return users;
    }
}
