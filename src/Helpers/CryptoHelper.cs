using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class CryptoHelper
{
    private static readonly string key = "WgvNVqKE1b5TzoFyMongoKey12345678"; // 32 
    private static readonly string iv = "InitVector123456"; // 16 

    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            System.Diagnostics.Debug.WriteLine("Key length: " + Encoding.UTF8.GetBytes(key).Length); // 32
            System.Diagnostics.Debug.WriteLine("IV length: " + Encoding.UTF8.GetBytes(iv).Length);   // 16

            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.Close();
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public static string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                byte[] inputBytes = Convert.FromBase64String(encryptedText);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}