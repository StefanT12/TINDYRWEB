using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly IAppUser _currentUserService;

        public RequestLogger(ILogger<TRequest> logger, IAppUser currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("WebshopRequest: {name} {@UserID} {@Request}", 
                name, _currentUserService.UserID, request);

            return Task.CompletedTask;
        }
    }
}
