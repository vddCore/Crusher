namespace Crusher.Infrastructure
{
    public class UnrealFormatException : Exception
    {
        internal UnrealFormatException(string message)
            : base(message)
        {
        }

        internal UnrealFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}