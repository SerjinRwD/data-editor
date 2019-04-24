using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    /// <summary>
    /// Пара хэш-соль. Структура для представдения и хранения результата хэширования пароля с солью.
    /// </summary>
    public struct PasswordHashResult
    {
        /// <summary>
        /// base64-строка, представляющая хэш массив байт хэша
        /// </summary>
        public string HashBase64 { get; internal set; }

        /// <summary>
        /// base64-строка, представляющая масиив байт соли
        /// </summary>
        public string SaltBase64 { get; internal set; }
    }

    /// <summary>
    /// Провайдер для работы с паролями: генерация хэша пароля с солью и сверка.
    /// </summary>
    public class SaltedHashingProvider
    {
        private readonly RNGCryptoServiceProvider _rngcsp;
        private readonly SHA256CryptoServiceProvider _sha256;
        private readonly int _saltLength;

        /// <summary>
        /// Инициализация провайдера
        /// </summary>
        /// <param name="saltLength">Длина соли (в байтах)</param>
        public SaltedHashingProvider(int saltLength = 16)
        {
            _rngcsp = new RNGCryptoServiceProvider();
            _sha256 = new SHA256CryptoServiceProvider();
            _saltLength = saltLength;
        }

        /// <summary>
        /// Создать хэш пароля и его соль
        /// </summary>
        /// <param name="password">Исходный пароль</param>
        /// <returns>Пара хэш-соль</returns>
        public PasswordHashResult HashPassword(string password)
        {
            var salt = new byte[_saltLength];
            var pwdBytes = Encoding.UTF8.GetBytes(password);

            _rngcsp.GetBytes(salt);
            var hash = _sha256.ComputeHash(pwdBytes);

            var concat = new byte[hash.Length + salt.Length];

            Array.Copy(salt, 0, concat, 0, salt.Length);
            Array.Copy(hash, 0, concat, salt.Length, hash.Length);

            hash = _sha256.ComputeHash(concat);

            return new PasswordHashResult
            {
                HashBase64 = Convert.ToBase64String(hash),
                SaltBase64 = Convert.ToBase64String(salt)
            };
        }

        /// <summary>
        /// Сверить введённый пароль с хэшом.
        /// </summary>
        /// <param name="inputedPwd">Введённый пароль "как есть" (т.е. не хэш и не base64)</param>
        /// <param name="pwdBase64">base64 строка: хэш пароля, взятый из хранилища</param>
        /// <param name="saltBase64">base64 строка: соль хэша пароля, взятая из хранилища</param>
        /// <returns>true, если хэш введённого пароля совпадает с хранящимся хэшем</returns>
        public bool CheckPassword(string inputedPwd, string pwdBase64, string saltBase64)
        {
            var inPwdBytes = Encoding.UTF8.GetBytes(inputedPwd);
            var inPwdHash = _sha256.ComputeHash(inPwdBytes);
            var saltBytes = Convert.FromBase64String(saltBase64);

            var concat = new byte[inPwdHash.Length + saltBytes.Length];

            Array.Copy(saltBytes, 0, concat, 0, saltBytes.Length);
            Array.Copy(inPwdHash, 0, concat, saltBytes.Length, inPwdHash.Length);

            inPwdHash = _sha256.ComputeHash(concat);
            var userPwdHash = Convert.FromBase64String(pwdBase64);

            // Побайтовая сверка хэшей. Если все байты равны, получил true
            return userPwdHash.SequenceEqual(inPwdHash);
        }
    }
}
