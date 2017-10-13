using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDangVien.Code
{
    public class Decrypt
    {
        public static string DecryptPassword(string StringToDecrypt, string EncryptionKey)
        {
            int counter = 0;
            Random jumbleMethod = new Random(int.Parse(EncryptionKey));
            byte[] sourceBytes = Convert.FromBase64String(StringToDecrypt);
            byte[] keySet = new byte[sourceBytes.Length];
            jumbleMethod.NextBytes(keySet);
            for (counter = 0; counter <= sourceBytes.Length - 1; counter++)
            {
                sourceBytes[counter] = (byte) (sourceBytes[counter] ^ keySet[counter]);
            }
            string kq= System.Text.Encoding.UTF8.GetString(sourceBytes);
            return kq;
        }
    }  
}
