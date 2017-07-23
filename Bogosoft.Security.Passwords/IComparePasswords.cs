namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Indicates that an implementation is capable of comparing passwords.
    /// </summary>
    public interface IComparePasswords
    {
        /// <summary>
        /// Compare a given salt and password to a previously hashed password.
        /// </summary>
        /// <param name="salt">A sequence of bytes representing the salt.</param>
        /// <param name="password">A sequence of bytes representing the clear password.</param>
        /// <param name="hashed">
        /// A sequence of bytes representing a previous result of hashing a salt and password.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the given salt and password equals the given hashed password.
        /// </returns>
        bool Compare(byte[] salt, byte[] password, byte[] hashed);
    }
}