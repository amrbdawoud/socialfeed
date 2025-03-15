using System;

namespace socialfeed.Errors;

public class UserDeleteException(string message) : BaseException(StatusCodes.Status400BadRequest, message)
{

}
