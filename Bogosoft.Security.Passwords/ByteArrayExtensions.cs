namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Extended functionality byte array types.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Compare two arrays byte-for-byte. For any given value which corresponds to the shorter length
        /// of the two arrays the comparison will be done in constant time, with the intent being to mitigate
        /// timing attacks.
        /// </summary>
        /// <param name="bytes">The current byte array.</param>
        /// <param name="other">Another byte array to test for equality.</param>
        /// <returns>
        /// True if the two arrays are of the same length and each byte in the current sequence equals
        /// the byte in the other sequence for any given posiiton.
        /// </returns>
        public static bool ConstantTimeSequenceEquals(this byte[] bytes, byte[] other)
        {
            var result = bytes.Length ^ other.Length;

            for (var i = 0; i < bytes.Length && i < other.Length; i++)
            {
                result |= bytes[i] ^ other[i];
            }

            return result == 0;
        }
    }
}