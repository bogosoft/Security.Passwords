namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Indicates that an implementation is capable of generating a password hash as a sequence of bytes
    /// against a given salt and password.
    /// </summary>
    public interface IHashPasswords
    {
        /// <summary>
        /// Generate a password hash against a given salt and password.
        /// </summary>
        /// <param name="salt">A sequence of bytes representing a salt.</param>
        /// <param name="password">A sequence of bytes representing a clear password.</param>
        /// <returns>
        /// A sequence of bytes representing the result of hashing the given salt and password.
        /// </returns>
        byte[] Hash(byte[] salt, byte[] password);
    }
}