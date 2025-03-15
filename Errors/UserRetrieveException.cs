using System;

namespace socialfeed.Errors;

public class UserRetrieveException(string message) : BaseException(StatusCodes.Status400BadRequest, message)
{

}
