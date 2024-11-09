using System.Security.Cryptography;
using System.Text;

namespace Core.Helper;
public static class Extentions
{
    public static string HashPassword(this string password)
    {
       
        using (var sha256 = SHA256.Create())
        {
            byte[] combinedBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }


}
