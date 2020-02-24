namespace BaseXamarin.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiService
    {
        Task<bool> GetExampleAsync(Dictionary<string, string> exampleData);
    }
}
