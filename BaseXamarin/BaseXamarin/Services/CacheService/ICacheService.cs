namespace BaseXamarin.Services
{
    using System;
    using System.Threading.Tasks;

    public interface ICacheService
    {
        void Start();

        Task<T> GetLocal<T>(string key);
        Task SetLocal<T>(string key, T value);
        Task SetLocal<T>(string key, T value, TimeSpan expiration);
        Task InvalidateLocal(string key);
        Task InvalidateAllLocal();
        Task FlushLocal();
        Task VacuumLocal();


        Task<T> GetInMemory<T>(string key);
        Task SetInMemory<T>(string key, T value);
        Task SetInMemory<T>(string key, T value, TimeSpan expiration);
        Task InvalidateInMemory(string key);
        Task InvalidateAllInMemory();
        Task FlushInMemory();
        Task VacuumInMemory();


        Task<T> GetUserAccount<T>(string key);
        Task SetUserAccount<T>(string key, T value);
        Task SetUserAccount<T>(string key, T value, TimeSpan expiration);
        Task InvalidateUserAccount(string key);
        Task InvalidateAllUserAccount();
        Task FlushUserAccount();
        Task VacuumUserAccount();


        Task<T> GetSecure<T>(string key);
        Task SetSecure<T>(string key, T value);
        Task SetSecure<T>(string key, T value, TimeSpan expiration);
        Task InvalidateSecure(string key);
        Task InvalidateAllSecure();
        Task FlushSecure();
        Task VacuumSecure();


        Task<T> GetAndFetch<T>(string key, Func<IObservable<T>> func, DateTimeOffset? expiration);
        Task<T> GetOrFetch<T>(string key, Func<IObservable<T>> func, DateTimeOffset? expiration);
    }
}
