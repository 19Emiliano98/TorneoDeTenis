using JwtSecurity;
using Services.Interfaces.User;
using System.Security.Cryptography;
using System.Text;

namespace Services.Services.User
{
    public class EncryptionService : IEncryptionService
    {
        private readonly EncryptionOptions _encryp;

        public EncryptionService(EncryptionOptions encrypt)
        {
            _encryp = encrypt;
        }


        public string Encrypt(string name)
        {
            return Encrypt(name, _encryp.EncryptionKey);
        }

        public string Decrypt(string name)
        {
            return Encrypt(name, _encryp.EncryptionKey);
        }
        // validar forbidden

        private string Encrypt(string plainText, string key)
        {
            var iv = new byte[16];
            byte[] array;

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }


        private string Decrypt(string data, string key)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(data);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(buffer))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

     
    }
}
