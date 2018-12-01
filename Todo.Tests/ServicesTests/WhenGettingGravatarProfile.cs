using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shouldly;
using Todo.Services;
using Todo.TagHelpers;
using Xunit;

namespace Todo.Tests.ServicesTests
{

    public class WhenGettingGravatarProfile : InMemoryCache
    {

        private Mock<IGravatar> _mock;
        private TagHelperContext _context;
        private TagHelperOutput _output;
        private TagHelperAttributeList _tagHelperAttributeList;
        private GravatarTagHelper _gravatarTagHelper;



        
        public WhenGettingGravatarProfile()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            var hash = "1234";
            var name = "name";
            var image = "image";
            _mock = new Mock<IGravatar>();
            _mock.Setup(g => g.GetHash(It.IsAny<string>())).Returns(hash);
            _mock.Setup(g => g.GetGravatarName(hash)).ReturnsAsync(name);
            _mock.Setup(g => g.GetGravatarImage(hash)).ReturnsAsync(image);
            
            _tagHelperAttributeList = new TagHelperAttributeList();
        }

        [Fact]
        public void WhenGravatarNameIsDisplayed()
        {
            _tagHelperAttributeList.Add("data-gravatar-name", "");
            _context = new TagHelperContext(_tagHelperAttributeList, new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            _output = new TagHelperOutput("strong", _tagHelperAttributeList, (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent(string.Empty);
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            _gravatarTagHelper = new GravatarTagHelper(_cache, _mock.Object);
            _gravatarTagHelper.ProcessAsync(_context, _output).Wait();
            _output.Content.GetContent().ShouldBe("name");


        }

        [Fact]
        public void WhenGravatarImageIsDisplayed()
        {
            _tagHelperAttributeList.Add("data-gravatar-image", "");
            _context = new TagHelperContext(_tagHelperAttributeList, new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            _output = new TagHelperOutput("img", _tagHelperAttributeList, (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent(string.Empty);
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            _gravatarTagHelper = new GravatarTagHelper(_cache, _mock.Object);
            _gravatarTagHelper.ProcessAsync(_context, _output).Wait();
            _output.Attributes[_output.Attributes.IndexOfName("src")].Value.ShouldBe("image");


        }


    }
}
