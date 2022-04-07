using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Task3
{
    class Keygen
    {
        private byte[] secretkey = new Byte[32];

        public Keygen()
        {
            Generateakey();
        }

        public byte[] GetKey()
        {
            return secretkey;
        }

        public string ShowKey()
        {
            return BitConverter.ToString(secretkey).Replace("-", string.Empty);
        }

        public void Generateakey()
        {
            using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(secretkey);
        }
    }
}
