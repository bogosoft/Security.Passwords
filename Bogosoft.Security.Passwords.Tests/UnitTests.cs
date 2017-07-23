using NUnit.Framework;
using Should;
using System;

namespace Bogosoft.Security.Passwords.Tests
{
    [TestFixture, Category("Unit")]
    public class UnitTests
    {
        const string Password = "Hello, World!";

        [TestCase]
        public void CsprngSaltGeneratorCreatesSaltOfLengthEqualToGivenLength()
        {
            var expected = 64;

            var salt = new CsprngSaltGenerator().Generate(expected);

            salt.Length.ShouldEqual(expected);
        }

        [TestCase]
        public void CsprngSaltGeneratorThrowsArgumentExceptionWhenGivenLengthIsLessThanZero()
        {
            Action operation = () => new CsprngSaltGenerator().Generate(-1);

            operation.ShouldThrow<ArgumentException>(Message.NegativeLength);
        }

        [TestCase]
        public void Pbkdf2PasswordHasherCanRoundTrip()
        {
            var hashsize = 32;
            var saltsize = hashsize * 2;

            var salt = new CsprngSaltGenerator().Generate(saltsize);

            salt.Length.ShouldEqual(saltsize);

            var hasher = new Pbkdf2PasswordHasher(hashsize);

            var hashed = hasher.Hash(salt, Password);

            hashed.Length.ShouldEqual(hashsize);

            hasher.Compare(salt, Password, hashed).ShouldBeTrue();
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentExceptionWhenConstructedWithNegativeHashSize()
        {
            Action operation = () => new Pbkdf2PasswordHasher(-1);

            operation.ShouldThrow<ArgumentException>(Message.NegativeLength);
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentExceptionWhenConstructedWithNegativeIterationValue()
        {
            Action operation = () => new Pbkdf2PasswordHasher(32, -1);

            operation.ShouldThrow<ArgumentException>(Message.NegativeIterations);
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentNullExceptionForCompareWhenGivenSaltIsNull()
        {
            Action operation = () => new Pbkdf2PasswordHasher(32).Compare(null, new byte[0], new byte[0]);

            operation.ShouldThrow<ArgumentNullException>();
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentNullExceptionForCompareWhenGivenPasswordIsNull()
        {
            Action operation = () => new Pbkdf2PasswordHasher(32).Compare(new byte[0], null, new byte[0]);

            operation.ShouldThrow<ArgumentNullException>();
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentNullExceptionForCompareWhenGivenHashedPasswordIsNull()
        {
            Action operation = () => new Pbkdf2PasswordHasher(32).Compare(new byte[0], new byte[0], null);

            operation.ShouldThrow<ArgumentNullException>();
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentNullExceptionForHashWhenGivenSaltIsNull()
        {
            Action operation = () => new Pbkdf2PasswordHasher(32).Hash(null, new byte[0]);

            operation.ShouldThrow<ArgumentNullException>();
        }

        [TestCase]
        public void Pbkdf2PasswordHasherThrowsArgumentNullExceptionForHashWhenGivenPasswordIsNull()
        {
            Action operation = () => new Pbkdf2PasswordHasher(32).Hash(new byte[0], null);

            operation.ShouldThrow<ArgumentNullException>();
        }
    }
}