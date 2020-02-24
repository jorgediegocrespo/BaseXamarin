namespace BaseXamarin.Services
{
    using Polly;
    using Polly.Fallback;
    using Polly.Retry;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ApiService : IApiService
    {
        public readonly IRefitApiService refitApiService;
        private const int NUMBER_OF_RETRIES = 3;

        public ApiService()
        {
            HttpClient httpClient = new HttpClient(new CustomHttpClientHandler()) { BaseAddress = new Uri(ApiServiceKeys.ApiServiceBaseUrl) };
            refitApiService = RestService.For<IRefitApiService>(httpClient);
        }

        public async Task<bool> GetExampleAsync(Dictionary<string, string> exampleData)
        {
            var response = await ExecuteApiFunc<bool>(() => refitApiService.GetExampleAsync(exampleData));
            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;
            else
                return false;
        }

        private async Task<ApiResponse<T>> ExecuteApiFunc<T>(Func<Task<ApiResponse<T>>> apifunc)
        {
            AsyncRetryPolicy retryPolicy = Policy
                .Handle<ApiException>(ex => ex.StatusCode == HttpStatusCode.RequestTimeout)
                .RetryAsync(NUMBER_OF_RETRIES, async (exception, retryCount) => await Task.Delay(500).ConfigureAwait(false));

            AsyncRetryPolicy unauthorizedPolicy = Policy
                .Handle<ApiException>(ex => ex.StatusCode == HttpStatusCode.Unauthorized)
                .RetryAsync(async (exception, retryCount) => await AuthenticationTask().ConfigureAwait(false));

            AsyncFallbackPolicy fallbackPolicy = Policy
                .Handle<Exception>()
                .FallbackAsync(async (cancellationToken) => await FallBackTask().ConfigureAwait(false));

            return await fallbackPolicy
                .WrapAsync(unauthorizedPolicy)
                .WrapAsync(retryPolicy)
                .ExecuteAsync(async () => await apifunc().ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        private Task AuthenticationTask()
        {
            return Task.CompletedTask;
        }

        private Task FallBackTask()
        {
            return Task.CompletedTask;
        }
    }
}
