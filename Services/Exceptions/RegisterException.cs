namespace Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException(string message, string code) : base($"{code}:{message}")
        {
        }
    }
}
