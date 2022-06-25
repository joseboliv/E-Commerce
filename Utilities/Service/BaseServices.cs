namespace Utilities.Service
{
    using Microsoft.Extensions.Logging;
    using System;

    public class BaseServices<T>
    {
        protected readonly ILogger<T> logger;
        public BaseServices(ILogger<T> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
