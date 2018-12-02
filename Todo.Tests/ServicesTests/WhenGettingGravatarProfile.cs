using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Shouldly;
using Todo.Services;
using Todo.TagHelpers;
using Xunit;

namespace Todo.Tests.ServicesTests
{

    public class WhenGettingGravatarProfile : InMemoryCache
    {
        private readonly Mock<IGravatar> mockGravatar;
        private TagHelperContext context;
        private TagHelperOutput output;
        private GravatarTagHelper gravatarTagHelper;

        public WhenGettingGravatarProfile()
        {
            Cache = new MemoryCache(new MemoryCacheOptions());
            var hash = "1234";
            var name = "name";
            var image = "image";

            mockGravatar = new MockGravatar()
                .GetHash(output: hash)
                .GetGravatarName(hash, output: name)
                .GetGravatarImage(hash, output: image);            
        }

        [Fact]
        public void WhenGravatarNameIsDisplayed()
        {
            //Arrange
            context = new TagHelperContextBuilder()
                .AddAttribute("data-gravatar-name", "")
                .Build();
            output = new TagHelperOutputBuilder("strong").Build();
            gravatarTagHelper = new GravatarTagHelper(Cache, mockGravatar.Object);
            
            //Act
            gravatarTagHelper.ProcessAsync(context, output).Wait();
            
            //Assert
            output.Content.GetContent().ShouldBe("name");
        }

        [Fact]
        public void WhenGravatarImageIsDisplayed()
        {
            //Arrange
            context = new TagHelperContextBuilder()
                .AddAttribute("data-gravatar-image", "")
                .Build();
            output = new TagHelperOutputBuilder("img").Build();
            gravatarTagHelper = new GravatarTagHelper(Cache, mockGravatar.Object);
            
            //Act
            gravatarTagHelper.ProcessAsync(context, output).Wait();

            //Assert
            var outputSrcValue = output.Attributes[output.Attributes.IndexOfName("src")];
            outputSrcValue.Value.ShouldBe("image");
        }
    }
}
