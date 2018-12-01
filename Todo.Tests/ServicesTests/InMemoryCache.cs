using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Todo.Tests.ServicesTests
{
    public class InMemoryCache : IDisposable
    {
        protected IMemoryCache _cache;

        public InMemoryCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public void Dispose()
        {
            _cache?.Dispose();
        }
    }
}
