using System.Net.Http;
namespace BaseXamarin.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    internal class CustomHttpClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("api-key", ApiServiceKeys.ApiServiceAuthorizationKey);
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}