using System;

namespace socialfeed.Errors;

public abstract class BaseException(int statusCode, string message) : Exception
{
    public int StatusCode { get; } = statusCode;
    public string ErrorMessage { get; } = message;

}
