namespace BaseXamarin.Services
{
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRefitApiService
    {
        [Get("/api/endpointUrl/{example}")]
        Task<ApiResponse<bool>> GetExampleAsync([Body]Dictionary<string, string> exampleData);
    }
}
