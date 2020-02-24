#if MOCK
[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.Services.MockApiService))]
#endif
namespace BaseXamarin.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MockApiService : IApiService
    {
        public Task<bool> GetExampleAsync(Dictionary<string, string> exampleData)
        {
            return Task.FromResult(true);
        }
    }
}
