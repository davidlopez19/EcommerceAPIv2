using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace EcommerceAPI.Dominio.Services.Encripcion
{
    public class CryptoService : ICryptoService
    {
        private readonly IConfiguration _configuration;
        private readonly string _key;
        private readonly string _IV;

        public CryptoService(IConfiguration configuration)
        {
            _configuration = configuration;
            this._key = _configuration["Crypto:KeySecret"] ?? string.Empty;
            this._IV= _configuration["Crypto:IV"] ?? string.Empty;
        }

        public string Encript(string value)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(_IV);

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(value);
                            }
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public string DesEncript(string value)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(_IV);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(value)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
