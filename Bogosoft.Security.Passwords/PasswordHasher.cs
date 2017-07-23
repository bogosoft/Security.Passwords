namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Generate a password hash against a given salt and password.
    /// </summary>
    /// <param name="salt">A sequence of bytes representing a salt.</param>
    /// <param name="password">A sequence of bytes representing a clear password.</param>
    /// <returns>
    /// A sequence of bytes representing the result of hashing the given salt and password.
    /// </returns>
    public delegate byte[] PasswordHasher(byte[] salt, byte[] password);
}