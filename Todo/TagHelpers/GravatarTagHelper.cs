using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using Todo.Services;

namespace Todo.TagHelpers
{
    [HtmlTargetElement(Attributes = "data-gravatar-name")]
    [HtmlTargetElement(Attributes = "data-gravatar-image")]
    public class GravatarTagHelper : TagHelper
    {
        private readonly IMemoryCache _cache;
        private readonly IGravatar _gravatar;

        public GravatarTagHelper(IMemoryCache cache, IGravatar gravatar)
        {
            _cache = cache;
            _gravatar = gravatar;
        }

        public string ResParty { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var hash = _gravatar.GetHash(ResParty);

            if (!_cache.TryGetValue(hash, out var cacheEntry))
            {
                var name = await _gravatar.GetGravatarName(hash);
                var image = await _gravatar.GetGravatarImage(hash);

                cacheEntry =  new GravatarProfile(name, image);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(hash, cacheEntry, cacheEntryOptions);
            }

            var profile = cacheEntry as GravatarProfile;

            if (context.AllAttributes.ContainsName("data-gravatar-name"))
            {
                output.Content.SetContent(profile?.Name);
            }

            if (context.AllAttributes.ContainsName("data-gravatar-image"))
            {
                output.Attributes.SetAttribute("src", profile?.Image);
            }

        }

        
    }

    public class GravatarProfile
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public GravatarProfile(string gravatarName, string gravatarImage)
        {
            Name = gravatarName;
            Image = gravatarImage;
        }
    }

}
