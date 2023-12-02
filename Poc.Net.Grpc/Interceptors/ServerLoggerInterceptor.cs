using Grpc.Core.Interceptors;
using Grpc.Core;
using System.Diagnostics;

namespace Poc.Net.Grpc.Interceptors
{
    public class ServerLoggerInterceptor : Interceptor
    {
        private readonly ILogger _logger;

        public ServerLoggerInterceptor(ILogger<ServerLoggerInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            _logger.LogInformation("Starting receiving call. Type/Method: {Type} / {Method}",
                MethodType.Unary, context.Method);
            try
            {
                var watcher = Stopwatch.StartNew();
                var result = await continuation(request, context);
                watcher.Stop();
                
                _logger.LogInformation("Finish receiving call. Type/Method: {Type} / {Method}, and took: {Time} to complete!",
                MethodType.Unary, context.Method, watcher.Elapsed);

                return result;
            }
            catch (Exception ex)
            {
                string message = $"Error thrown by {context.Method}.";
                _logger.LogError(ex, message);
                throw;
            }
        }
    }
}