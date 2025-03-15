using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using socialfeed.Data;
using socialfeed.Errors;
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
            return user;
        }
        catch (Exception e)
        {

            throw new UserCreationException(e.Message);
        }
    }
    public User? GetUser(int id)
    {
        try
        {
            var user = _context.Users
            .Where(u => u.Id == id && !u.IsDeleted)
            .FirstOrDefault(); // Note: should i use async?
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            return user;
        }
        catch (System.Exception e)
        {

            throw new UserRetrieveException(e.Message);
        }
    }
    public List<User> GetUsers()
    {
        try
        {
            List<User> users = _context.Users
            .Where(u => !u.IsDeleted)
            .ToList();
            return users;
        }
        catch (System.Exception e)
        {

            throw new UserRetrieveException(e.Message);
        }
    }
    public User? EditUser(int id, User user)
    {
        try
        {
            var existingUser = _context.Users
                .Where(u => u.Id == id && !u.IsDeleted)
                .FirstOrDefault();

            if (existingUser == null)
            {
                throw new UserNotFoundException(id);
            }

            // Update only the fields that can be edited
            existingUser.Name = user.Name;
            existingUser.Bio = user.Bio;

            _context.SaveChanges();
            return existingUser;
        }
        catch (Exception e)
        {
            throw new UserUpdateException(e.Message);
        }
    }
    public User? DeleteUser(int id)
    {
        try
        {
            var userToDelete = _context.Users
            .Where(u => u.Id == id && !u.IsDeleted)
            .FirstOrDefault();
            if (userToDelete == null || userToDelete.IsDeleted)
            {
                throw new UserNotFoundException(id);
            }
            userToDelete.IsDeleted = true;
            _context.SaveChanges();
            return userToDelete;

        }
        catch (Exception e)
        {

            throw new UserDeleteException(e.Message);
        }
    }

}
