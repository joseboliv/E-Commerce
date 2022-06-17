namespace Authentication.Jwt
{
    public interface IJwtFactory
    {
        string GenerateEncodedToken<T>(T model);
    }
}