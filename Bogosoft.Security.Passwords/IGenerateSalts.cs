namespace Bogosoft.Security.Passwords
{
    /// <summary>
    /// Indicates that an implementation is capable of generating a sequence of bytes
    /// as a password salt of any given length.
    /// </summary>
    public interface IGenerateSalts
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
        byte[] Generate(int size);
    }
}