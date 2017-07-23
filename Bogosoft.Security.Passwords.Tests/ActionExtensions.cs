using Should;
using System;

namespace Bogosoft.Security.Passwords.Tests
{
    static class ActionExtensions
    {
        internal static void ShouldThrow<T>(this Action action, string expectedMessage) where T : Exception
        {
            Exception exception = null;

            try
            {
                action.Invoke();
            }
            catch(Exception e)
            {
                exception = e;
            }

            exception.ShouldNotBeNull();

            exception.ShouldBeType<T>();

            exception.Message.ShouldEqual(expectedMessage);
        }
    }
}