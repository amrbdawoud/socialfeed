using System;

namespace socialfeed.Errors;

public class UserUpdateException(string message) : BaseException(StatusCodes.Status400BadRequest, message)
{

}
