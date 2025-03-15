using System;

namespace socialfeed.Errors;

public class UserCreationException(string message) : BaseException(StatusCodes.Status400BadRequest, message)
{

}
