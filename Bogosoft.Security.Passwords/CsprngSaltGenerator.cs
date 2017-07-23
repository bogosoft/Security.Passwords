using System;
using System.Security.Cryptography;

namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// An implementation of the <see cref="IGenerateSalts"/> contract based
    /// on the <see cref="RNGCryptoServiceProvider"/> type.
    /// </summary>
    public sealed class CsprngSaltGenerator : IGenerateSalts
    {
        /// <summary>
        /// Generate a password salt as a sequence of bytes of a given size.
        /// </summary>
        /// <param name="size">
        /// A value corresponding to the size of the resulting salt.
        /// </param>
        /// <returns>
        /// A password salt as a sequence of bytes of the given size.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown in the event that the given length is less than zero.
        /// </exception>
        public byte[] Generate(int size)
        {
            if(size < 0)
            {
                throw new ArgumentException(Message.NegativeLength);
            }

            var salt = new byte[size];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}