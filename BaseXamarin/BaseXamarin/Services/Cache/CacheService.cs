[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.Services.CacheService))]
namespace BaseXamarin.Services
{
    using Akavache;
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    public class CacheService : ICacheService
    {
        public async Task<T> GetLocal<T>(string key)
        {
            return await BlobCache.LocalMachine.GetObject<T>(key);
        }

        public async Task SetLocal<T>(string key, T value)
        {
            await BlobCache.LocalMachine.InsertObject<T>(key, value);
        }

        public async Task SetLocal<T>(string key, T value, TimeSpan expiration)
        {
            await BlobCache.LocalMachine.InsertObject<T>(key, value, expiration);
        }

        public async Task InvalidateLocal(string key)
        {
            await BlobCache.LocalMachine.Invalidate(key);
        }

        public async Task InvalidateAllLocal()
        {
            await BlobCache.LocalMachine.InvalidateAll();
        }

        public async Task FlushLocal()
        {
            await BlobCache.LocalMachine.Flush();
        }

        public async Task VacuumLocal()
        {
            await BlobCache.LocalMachine.Vacuum();
        }



        public async Task<T> GetInMemory<T>(string key)
        {
            return await BlobCache.InMemory.GetObject<T>(key);
        }

        public async Task SetInMemory<T>(string key, T value)
        {
            await BlobCache.InMemory.InsertObject<T>(key, value);
        }

        public async Task SetInMemory<T>(string key, T value, TimeSpan expiration)
        {
            await BlobCache.InMemory.InsertObject<T>(key, value, expiration);
        }

        public async Task InvalidateInMemory(string key)
        {
            await BlobCache.InMemory.Invalidate(key);
        }

        public async Task InvalidateAllInMemory()
        {
            await BlobCache.InMemory.InvalidateAll();
        }

        public async Task FlushInMemory()
        {
            await BlobCache.InMemory.Flush();
        }

        public async Task VacuumInMemory()
        {
            await BlobCache.InMemory.Vacuum();
        }



        public async Task<T> GetUserAccount<T>(string key)
        {
            return await BlobCache.UserAccount.GetObject<T>(key);
        }

        public async Task SetUserAccount<T>(string key, T value)
        {
            await BlobCache.UserAccount.InsertObject<T>(key, value);
        }

        public async Task SetUserAccount<T>(string key, T value, TimeSpan expiration)
        {
            await BlobCache.UserAccount.InsertObject<T>(key, value, expiration);
        }

        public async Task InvalidateUserAccount(string key)
        {
            await BlobCache.UserAccount.Invalidate(key);
        }

        public async Task InvalidateAllUserAccount()
        {
            await BlobCache.UserAccount.InvalidateAll();
        }

        public async Task FlushUserAccount()
        {
            await BlobCache.UserAccount.Flush();
        }

        public async Task VacuumUserAccount()
        {
            await BlobCache.UserAccount.Vacuum();
        }



        public async Task<T> GetSecure<T>(string key)
        {
            return await BlobCache.Secure.GetObject<T>(key);
        }

        public async Task SetSecure<T>(string key, T value)
        {
            await BlobCache.Secure.InsertObject<T>(key, value);
        }

        public async Task SetSecure<T>(string key, T value, TimeSpan expiration)
        {
            await BlobCache.Secure.InsertObject<T>(key, value, expiration);
        }

        public async Task InvalidateSecure(string key)
        {
            await BlobCache.Secure.Invalidate(key);
        }

        public async Task InvalidateAllSecure()
        {
            await BlobCache.Secure.InvalidateAll();
        }

        public async Task FlushSecure()
        {
            await BlobCache.Secure.Flush();
        }

        public async Task VacuumSecure()
        {
            await BlobCache.Secure.Vacuum();
        }



        public async Task<T> GetAndFetch<T>(string key, Func<IObservable<T>> func, DateTimeOffset? expiration)
        {
            return await BlobCache.LocalMachine.GetAndFetchLatest<T>(key, func, null, expiration);
        }

        public async Task<T> GetOrFetch<T>(string key, Func<IObservable<T>> func, DateTimeOffset? expiration)
        {
            return await BlobCache.LocalMachine.GetOrFetchObject<T>(key, func, expiration);
        }
    }
}
