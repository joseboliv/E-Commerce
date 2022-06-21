namespace Authentication
{
    public interface ICredential
    {
        object GenerateUserCredential(string password);
        bool SignIn(object source, string password);
    }
}