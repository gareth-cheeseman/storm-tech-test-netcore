using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using Todo.Services;
using Todo.TagHelpers;

namespace Todo.Tests.ServicesTests
{
    public class TagHelperContextBuilder 
    {
        private TagHelperAttributeList attributeList;
        private TagHelperContext context;
       


        public TagHelperContextBuilder() 
        {
            attributeList = new TagHelperAttributeList();
        }

        public TagHelperContextBuilder AddAttribute(string name, string value)
        {
            attributeList.Add(name, value);
            return this;
        }

        public TagHelperContext Build()
        {
            context = new TagHelperContext(attributeList, new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            return context;
        }
    }
}
