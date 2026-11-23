using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGRIVA.Models;

namespace AGRIVA.Tests.Models
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void Hash_AndVerify_WithCorrectPassword_ReturnsTrue()
        {
            string hash = PasswordHasher.Hash("contoh-password");

            Assert.IsTrue(PasswordHasher.Verify("contoh-password", hash));
        }

        [TestMethod]
        public void Verify_WithWrongPassword_ReturnsFalse()
        {
            string hash = PasswordHasher.Hash("password-benar");

            Assert.IsFalse(PasswordHasher.Verify("password-salah", hash));
        }

        [TestMethod]
        public void Hash_CalledTwice_ProducesDifferentHashesBecauseSaltIsRandom()
        {
            string firstHash = PasswordHasher.Hash("password-sama");
            string secondHash = PasswordHasher.Hash("password-sama");

            Assert.AreNotEqual(firstHash, secondHash);
            Assert.IsTrue(PasswordHasher.Verify("password-sama", firstHash));
            Assert.IsTrue(PasswordHasher.Verify("password-sama", secondHash));
        }

        [TestMethod]
        public void Verify_WithNullOrEmptyInput_ReturnsFalse()
        {
            Assert.IsFalse(PasswordHasher.Verify(null, "hash"));
            Assert.IsFalse(PasswordHasher.Verify("", "hash"));
            Assert.IsFalse(PasswordHasher.Verify("password", null));
            Assert.IsFalse(PasswordHasher.Verify("password", ""));
        }

        [TestMethod]
        public void Verify_WithMalformedHash_ReturnsFalse()
        {
            Assert.IsFalse(PasswordHasher.Verify("password", "bukan-format-hash"));
            Assert.IsFalse(PasswordHasher.Verify("password", "PBKDF2-SHA256$abc$%%%$%%%"));
        }

        [TestMethod]
        public void Hash_WithNullPassword_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(
                () => PasswordHasher.Hash(null));
        }
    }
}
