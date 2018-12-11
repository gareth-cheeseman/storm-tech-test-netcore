using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Services
{
    public class GravatarUrl : IGravatarUrl
    {
        public string ProfileUrl(string hash)
        {
            return $"/{hash}.json";

        }

        public string ImageUrl(string hash, int size)
        {
            return $"/avatar/{hash}?s={size}";
        }
    }
}
