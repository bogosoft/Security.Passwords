namespace Bogosoft.Security.Passwords
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
    public delegate byte[] SaltGenerator(int size);
}