namespace Infrastructure.EfCore
{
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public interface IDbFacadeResolver
    {
        DatabaseFacade Database { get; }
    }
}
