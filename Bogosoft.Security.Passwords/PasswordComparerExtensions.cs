using System.Text;

namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Extended functionality for the <see cref="PasswordComparer"/>
    /// and <see cref="IComparePasswords"/> contracts.
    /// </summary>
    public static class PasswordComparerExtensions
    {
        /// <summary>
        /// Compare a given salt and password to a previously hashed password.
        /// </summary>
        /// <param name="comparer">The current <see cref="IComparePasswords"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing the salt.</param>
        /// <param name="password">A string representing the clear password.</param>
        /// <param name="hashed">
        /// A sequence of bytes representing a previous result of hashing a salt and password.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the given salt and password equals the given hashed password.
        /// </returns>
        public static bool Compare(this IComparePasswords comparer, byte[] salt, string password, byte[] hashed)
        {
            return comparer.Compare(salt, Encoding.Unicode.GetBytes(password), hashed);
        }

        /// <summary>
        /// Compare a given salt and password to a previously hashed password.
        /// </summary>
        /// <param name="comparer">The current <see cref="IComparePasswords"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing the salt.</param>
        /// <param name="password">A string representing the clear password.</param>
        /// <param name="hashed">
        /// A sequence of bytes representing a previous result of hashing a salt and password.
        /// </param>
        /// <param name="encoding">
        /// An encoding to use to convert the given password to an array of bytes.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the given salt and password equals the given hashed password.
        /// </returns>
        public static bool Compare(
            this IComparePasswords comparer,
            byte[] salt,
            string password,
            byte[] hashed,
            Encoding encoding
            )
        {
            return comparer.Compare(salt, encoding.GetBytes(password), hashed);
        }

        /// <summary>
        /// Compare a given salt and password to a previously hashed password.
        /// </summary>
        /// <param name="delegate">The current <see cref="PasswordComparer"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing the salt.</param>
        /// <param name="password">A sequence of bytes representing the clear password.</param>
        /// <param name="hashed">
        /// A sequence of bytes representing a previous result of hashing a salt and password.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the given salt and password equals the given hashed password.
        /// </returns>
        public static bool Compare(this PasswordComparer @delegate, byte[] salt, byte[] password, byte[] hashed)
        {
            return @delegate.Invoke(salt, password, hashed);
        }

        /// <summary>
        /// Compare a given salt and password to a previously hashed password.
        /// </summary>
        /// <param name="delegate">The current <see cref="PasswordComparer"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing the salt.</param>
        /// <param name="password">A string representing the clear password.</param>
        /// <param name="hashed">
        /// A sequence of bytes representing a previous result of hashing a salt and password.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the given salt and password equals the given hashed password.
        /// </returns>
        public static bool Compare(this PasswordComparer @delegate, byte[] salt, string password, byte[] hashed)
        {
            return @delegate.Invoke(salt, Encoding.Unicode.GetBytes(password), hashed);
        }

        /// <summary>
        /// Compare a given salt and password to a previously hashed password.
        /// </summary>
        /// <param name="delegate">The current <see cref="PasswordComparer"/> implementation.</param>
        /// <param name="salt">A sequence of bytes representing the salt.</param>
        /// <param name="password">A string representing the clear password.</param>
        /// <param name="hashed">
        /// A sequence of bytes representing a previous result of hashing a salt and password.
        /// </param>
        /// <param name="encoding">
        /// An encoding to use to convert the given password to an array of bytes.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the given salt and password equals the given hashed password.
        /// </returns>
        public static bool Compare(
            this PasswordComparer @delegate,
            byte[] salt,
            string password,
            byte[] hashed,
            Encoding encoding
            )
        {
            return @delegate.Invoke(salt, encoding.GetBytes(password), hashed);
        }
    }
}