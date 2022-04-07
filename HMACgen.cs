using System;
using System.Text;
using System.Security.Cryptography;


namespace Task3
{
    class HMACgen
    {
        private byte[] hashingword;
        private byte[] key;
        private byte[] hashValue;

        public HMACgen(string inpword, byte[] generatedkey)
        {
            hashingword = Encoding.Default.GetBytes(inpword);
            key = generatedkey;
            GenerateHashword();
        }

        public void SetKey(byte[] generatedkey)
        {
            key = generatedkey;
        }

        public void SetWord(string inpword)
        {
            hashingword = Encoding.Default.GetBytes(inpword);
        }

        public void GenerateHashword()
        {
            using HMACSHA256 hmac = new HMACSHA256(key);
            hashValue = hmac.ComputeHash(hashingword);
        }

        public string ShowHash()
        {
            return BitConverter.ToString(hashValue).Replace("-", string.Empty);
        }
    }
}
