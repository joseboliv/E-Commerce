namespace Authentication.ContextAccessor
{
    using System;

    public interface ISecurityContextAccessor
    {
        Guid UserId { get; }
        string Email { get; }
        string JwtToken { get; }
        bool IsAuthenticated { get; }
    }
}
