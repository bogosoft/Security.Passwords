# Bogosoft.Security.Passwords
This project contains contracts and implementations related to password security for .NET.

## Contracts

The following table lists the various contracts and their purposes that can be coded against in your application.

|Goal|Interface|Delegate|
|---|---|---|
|Compare a given salt and password to a previously hashed password.|`IComparePasswords`|`PasswordComparer`|
|Generate a salt for use in password hashing operations.|`IGenerateSalts`|`SaltGenerator`|
|Generate password hashes given a salt and a clear password.|`IHashPasswords`|`PasswordHasher`|

## Implementations

The following table lists the out-of-the-box concrete implementations of above interfaces.

|Name|Implemented Interfaces|Notes|
|---|---|---|
|`CsprngSaltGenerator`|`IGenerateSalts`|Uses `System.Security.Cryptography.RNGCryptoServiceProvider` for salt generation. The resulting salt is random enough to be considered cryptographically secure.|
|`Pbkdf2PasswordHasher`|`IComparePasswords`, `IHashPasswords`|Password comparison and hashing strategy using the password-based key derivation functionality provided by the `System.Security.Cryptography.Rfc2898DeriveBytes` type.|

## Example Usage

The following examples are listed in the order of operations common to creating and later comparing password hashes.

### Generating a Salt

```csharp
// Let's make our salt twice the length of the password hash we want to end up with, which is 32.
var saltsize = 64;

// Generate the salt.
var salt = new CsprngSaltGenerator().Generate(saltsize);
```

Since this salt is randomly generated, you'll want to store this alongside the hashed password (which we'll be going over next) in your data storage provider of choice.

### Generating a Password Hash

```csharp
// Instantiate a new hash provider.
IHashPasswords hasher = new Pbkdf2PasswordHasher(saltsize / 2);

// Declare a password.
var password = "Hello, World!";

// Generate a hash against it.
var hashed = hasher.Hash(salt, password);
```

Obviously you'll be storing this. Don't forget to store the salt we generated earlier alongside it.

### Comparing a Given Password to a Password Hash

```csharp
// Instantiate a new password hash comparer.
IComparePasswords comparer = new Pbkdf2PasswordHasher(saltsize / 2);

// Perform the comparison.
if(Comparer.Compare(salt, password, hashed))
{
    // Authenticated!
}
else
{
    // User-given password is not a match. Don't let them in.
}
```

## NuGet Providers

|Branch|Package ID|Feed URL|
|---|---|---|
|develop|`Bogosoft.Security.Passwords`|https://www.myget.org/feed/bogolib/package/nuget/Bogosoft.Security.Passwords|

## Additional Notes

Various QOL extension methods are included. The contracts may ask for byte arrays, but you can just as easily pass in string passwords and achieve the same results.

This project does its best to mitigate timing attacks during password hash comparison by using constant-time byte array comparisons.
