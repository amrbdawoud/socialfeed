using System;

namespace socialfeed.Errors;

public class NotFoundException(string message) : BaseException(StatusCodes.Status404NotFound, message)
{

}
