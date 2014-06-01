using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ServiceHub.Application;

namespace ServiceHub.Test.Unit.Application
{
    [TestFixture]
    public class TestEncryptor
    {
        [Test]
        public void Encryptor_can_encrypt_and_decrypt_a_string()
        {
            var testString = "teststring";

            var encryptedString = Encryptor.Encrypt(testString);

            Console.Write(encryptedString);

            var decryptedString = Encryptor.Decrypt(encryptedString);

            Assert.AreEqual(testString, decryptedString);

        }

    }
}
