namespace SimpleConverter.WebApp.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate.Invoke(httpContext);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
        }
    }
}
