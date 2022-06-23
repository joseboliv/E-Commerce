namespace Utilities.Extensions
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public static class HasherExtensions
    {
        public static string SHA256(string text)
        {
            var result = default(string);

            using (var algo = new SHA256Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }

        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            // Compute hash from text parameter
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get has value in array of bytes
            var result = algo.Hash;

            // Return as hexadecimal string
            return string.Join(string.Empty, result.Select(x => x.ToString("x2")));
        }
    }
}
