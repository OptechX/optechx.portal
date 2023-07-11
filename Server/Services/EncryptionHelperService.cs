using System.Security.Cryptography;
using System.Text;

namespace OptechX.Portal.Server.Services
{
	public class EncryptionHelperService : IEncryptionHelperService
	{
        private const int KeySize = 256;
        private const int BlockSize = 128;

        public EncryptionHelperService()
        {
        }

        public string EncryptData(string value, Guid key)
        {
            byte[] encryptedBytes;
            using (Aes aesAlg = Aes.Create())
            {
                byte[] keyBytes = key.ToByteArray();
                byte[] iv = new byte[BlockSize / 8];
                byte[] valueBytes = Encoding.UTF8.GetBytes(value);

                aesAlg.KeySize = KeySize;
                aesAlg.BlockSize = BlockSize;
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(valueBytes, 0, valueBytes.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public string DecryptData(string encryptedValue, Guid key)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedValue);
            byte[] decryptedBytes;

            using (Aes aesAlg = Aes.Create())
            {
                byte[] keyBytes = key.ToByteArray();
                byte[] iv = new byte[BlockSize / 8];

                aesAlg.KeySize = KeySize;
                aesAlg.BlockSize = BlockSize;
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream msPlain = new MemoryStream())
                        {
                            int data;
                            while ((data = csDecrypt.ReadByte()) != -1)
                            {
                                msPlain.WriteByte((byte)data);
                            }
                            decryptedBytes = msPlain.ToArray();
                        }
                    }
                }
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}

