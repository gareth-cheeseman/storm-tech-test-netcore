using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Todo.Services;

namespace Todo.TagHelpers
{
    public class GravatarNameTagHelper : TagHelper
    {
        private readonly IMemoryCache _cache;
        private readonly IGravatar _gravatar;

        public GravatarNameTagHelper(IMemoryCache cache, IGravatar gravatar)
        {
            _cache = cache;
            _gravatar = gravatar;
        }

        public string ResParty { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var hash = Gravatar.GetHash(ResParty);
            if (!_cache.TryGetValue(hash, out var cacheEntry))
            {

                cacheEntry = await _gravatar.GetGravatarName(hash);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(hash, cacheEntry, cacheEntryOptions);
            }

            var displayName = cacheEntry as string;

            output.TagName = "span";
            output.Content.SetContent(displayName);
        }
    }


}
