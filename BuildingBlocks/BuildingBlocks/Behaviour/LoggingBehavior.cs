using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviour
{
    public class LoggingBehavior<TRequests, TResponse>
        (ILogger<LoggingBehavior<TRequests, TResponse>> logger)
        : IPipelineBehavior<TRequests, TResponse>
        where TRequests : notnull, IRequest<TResponse>
        where TResponse : notnull   
    {
        public async Task<TResponse> Handle(TRequests request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request={Request}-Response={Reponse}-RequestData={RequestData}",
                                  typeof(TResponse).Name, typeof(TRequests).Name,request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Start();

            var timeTaken = timer.Elapsed;
            if(timeTaken.Seconds > 3)
            {
                logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds",
                            typeof(TRequests).Name, timeTaken.Seconds);
            }

            logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TResponse).Name, response);
            return response;
        }
    }
}
