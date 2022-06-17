using System.Threading.Tasks;

namespace Authentication
{
    public interface ICredential
    {
        Task<(byte[], byte[], byte[], string)> ChangedPassword<T>(T source, string oldPassword, string newPassword);
        Task<T> GenerateUserCredential<T>(string username, string password);
        bool SignIn<T>(T source, string password);
    }
}