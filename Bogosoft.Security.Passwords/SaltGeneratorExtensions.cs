namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Extended functionality for the <see cref="SaltGenerator"/> contract.
    /// </summary>
    public static class SaltGeneratorExtensions
    {
        /// <summary>
        /// Generate a password salt as a sequence of bytes of a given size.
        /// </summary>
        /// <param name="delegate">The current <see cref="SaltGenerator"/> implementation.</param>
        /// <param name="size">
        /// A value corresponding to the size of the resulting salt.
        /// </param>
        /// <returns>
        /// A password salt as a sequence of bytes of the given size.
        /// </returns>
        public static byte[] Generate(this SaltGenerator @delegate, int size)
        {
            return @delegate.Invoke(size);
        }
    }
}