using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Todo.Tests.ServicesTests
{
    public class TagHelperOutputBuilder
    {
        private readonly string tag;

        public TagHelperOutputBuilder(string tag)
        {
            this.tag = tag;
        }


        public TagHelperOutput Build()
        {
            return new TagHelperOutput(tag, new TagHelperAttributeList(), (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent(string.Empty);
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
        }
    }
}
