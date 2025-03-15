using System;

namespace socialfeed.Errors;

public class UserNotFoundException(int id) : BaseException(StatusCodes.Status404NotFound, $"User with ID: {id} not found")
{

}
