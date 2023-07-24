using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace HouseRentWebApi.Shared.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("Api Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}