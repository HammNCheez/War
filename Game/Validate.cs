public static class Validate
{
  public static void IsNotNull<T>(T val)
  {
    if (val == null)
      throw new ValidationException("Value is null.");
  }

  public static void IsNotEmpty<T>(IEnumerable<T> val)
  {
    if (!val.Any())
      throw new ValidationException("Enumerable is Empty.");
  }

  public static void IsNotEmpty(string val)
  {
    if (string.IsNullOrEmpty(val))
      throw new ValidationException("String is Empty.");
  }

  public static void IsNotNullOrEmpty<T>(IEnumerable<T> val)
  {
    if (val == null)
      throw new ValidationException("Value is Null.");

    if (!val.Any())
    {
      throw new ValidationException("Enumerable is Empty.");
    }
  }


}

public class ValidationException : Exception
{
  public ValidationException()
  {
  }

  public ValidationException(string message)
      : base(message)
  {
  }

  public ValidationException(string message, Exception inner)
      : base(message, inner)
  {
  }
}