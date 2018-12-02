using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Todo.Tests.ServicesTests
{
    public class InMemoryCache : IDisposable
    {
        protected IMemoryCache Cache;

        public InMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions());
        }

        public void Dispose()
        {
            Cache?.Dispose();
        }
    }
}
