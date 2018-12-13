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
        private readonly IMemoryCache cache;
        private readonly IGravatar gravatar;

        public GravatarTagHelper(IMemoryCache cache, IGravatar gravatar)
        {
            this.cache = cache;
            this.gravatar = gravatar;
        }

        public string ResParty { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var hash = gravatar.GetHash(ResParty);

            if (!cache.TryGetValue(hash, out var cacheEntry))
            {
                var name = await gravatar.GetGravatarName(hash);
                var image = await gravatar.GetGravatarImage(hash);

                cacheEntry =  new GravatarProfile(name, image);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));

                cache.Set(hash, cacheEntry, cacheEntryOptions);
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
