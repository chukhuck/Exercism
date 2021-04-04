using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception("You need to implement this function.");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        return int.TryParse(input, out int output) ? (int?)output : null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        bool isSucceed = false;

        try
        {
            result = int.Parse(input);
            isSucceed = true;
        }
        catch (FormatException)
        {
            result = 0;
        }
        catch (Exception)
        {
            throw;
        }

        return isSucceed;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using (disposableObject)
        {
            throw new Exception("crash");
        }
    }
}
