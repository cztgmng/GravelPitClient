using System.Security.Cryptography;
using System.Text;

namespace GravelPit
{
    public static class Hashing
    {
        public static string Hash(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(data);
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return hashString;
            }
        }
    }
}
