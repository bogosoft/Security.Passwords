using System.Text;

namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Extended functionality for the <see cref="IHashPasswords"/> and
    /// <see cref="PasswordHasher"/> contracts.
    /// </summary>
    public static class PasswordHasherExtensions
    {
        /// <summary>
        /// Generate a password hash against a given salt and password.
        /// </summary>
        /// <param name="hasher">The current <see cref="IHashPasswords"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing a salt.</param>
        /// <param name="password">A string representing a clear password.</param>
        /// <returns>
        /// A sequence of bytes representing the result of hashing the given salt and password.
        /// </returns>
        public static byte[] Hash(this IHashPasswords hasher, byte[] salt, string password)
        {
            return hasher.Hash(salt, Encoding.Unicode.GetBytes(password));
        }

        /// <summary>
        /// Generate a password hash against a given salt and password.
        /// </summary>
        /// <param name="hasher">The current <see cref="IHashPasswords"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing a salt.</param>
        /// <param name="password">A string representing a clear password.</param>
        /// <param name="encoding">
        /// An encoding to use for converting the given string password to a sequence of bytes.
        /// </param>
        /// <returns>
        /// A sequence of bytes representing the result of hashing the given salt and password.
        /// </returns>
        public static byte[] Hash(this IHashPasswords hasher, byte[] salt, string password, Encoding encoding)
        {
            return hasher.Hash(salt, encoding.GetBytes(password));
        }

        /// <summary>
        /// Generate a password hash against a given salt and password.
        /// </summary>
        /// <param name="delegate">The current <see cref="PasswordHasher"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing a salt.</param>
        /// <param name="password">A sequence of bytes representing a clear password.</param>
        /// <returns>
        /// A sequence of bytes representing the result of hashing the given salt and password.
        /// </returns>
        public static byte[] Hash(this PasswordHasher @delegate, byte[] salt, byte[] password)
        {
            return @delegate.Invoke(salt, password);
        }

        /// <summary>
        /// Generate a password hash against a given salt and password.
        /// </summary>
        /// <param name="delegate">The current <see cref="PasswordHasher"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing a salt.</param>
        /// <param name="password">A string representing a clear password.</param>
        /// <returns>
        /// A sequence of bytes representing the result of hashing the given salt and password.
        /// </returns>
        public static byte[] Hash(this PasswordHasher @delegate, byte[] salt, string password)
        {
            return @delegate.Invoke(salt, Encoding.Unicode.GetBytes(password));
        }

        /// <summary>
        /// Generate a password hash against a given salt and password.
        /// </summary>
        /// <param name="delegate">The current <see cref="PasswordHasher"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing a salt.</param>
        /// <param name="password">A string representing a clear password.</param>
        /// <param name="encoding">
        /// An encoding to use for converting the given string password to a sequence of bytes.
        /// </param>
        /// <returns>
        /// A sequence of bytes representing the result of hashing the given salt and password.
        /// </returns>
        public static byte[] Hash(this PasswordHasher @delegate, byte[] salt, string password, Encoding encoding)
        {
            return @delegate.Invoke(salt, encoding.GetBytes(password));
        }
    }
}