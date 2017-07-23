namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// A collection of messages relating to password security notifications.
    /// </summary>
    public static class Message
    {
        /// <summary>
        /// Get a notification that an integer with a negative value was
        /// used to describe a number of iterations to be taken.
        /// </summary>
        public const string NegativeIterations = "A number of iterations cannot be less than 0.";

        /// <summary>
        /// Get a notification that an integer with a negative value was
        /// used to describe the length of something.
        /// </summary>
        public const string NegativeLength = "A length cannot be less than 0.";
    }
}