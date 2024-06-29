using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Forensilog
{
    internal class Calculate_Hash
    {
        public string Hashing(string data)
        {
            byte[] InputText = Encoding.UTF8.GetBytes(data);
            using (SHA256 obj = SHA256.Create())
            {
                byte[] hash = obj.ComputeHash(InputText);
                StringBuilder hashstring = new StringBuilder();
                foreach (byte b in hash)
                {
                    hashstring.Append(b.ToString("x2"));
                }
                return hashstring.ToString();
            }

        }
    }
}
