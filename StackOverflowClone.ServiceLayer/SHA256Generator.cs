using System.Security.Cryptography;
using System.Text;

namespace StackOverflowClone.ServiceLayer
{
    public class SHA256Generator
    {
        public static string GenerateHash(string password)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }

        }
    }
}
