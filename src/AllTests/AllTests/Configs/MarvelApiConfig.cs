using AllTests.Extensions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AllTests.Configs {
    public class MarvelApiConfig {

        private MarvelApiConfig() { }

        public static MarvelApiConfig GetRequestConfig() {
            var config = new MarvelApiConfig();
            config.Ts = DateTime.Now.ToJavascriptTimestamp();
            config.Hash = config.CalculateHash();

            return config;
        }

        public static string ApiBaseUrl => "https://gateway.marvel.com/v1/public";
        public long Ts { get; private set; }

        public string ApiPublicKey => "<Your Key here>";

        private static string ApiSecretKey => "<Your Key here>";

        public string Hash { get; private set; }

        private string CalculateHash() {
            var md5Hash = MD5.Create();
            var inputData = $"{Ts}{ApiSecretKey}{ApiPublicKey}";
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inputData));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}
