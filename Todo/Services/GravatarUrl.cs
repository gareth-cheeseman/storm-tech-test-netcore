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
            return $"https://www.gravatar.com/{hash}.json";

        }

        public string ImageUrl(string hash, int size)
        {
            return $"https://www.gravatar.com/avatar/${hash}?s={size}";
        }
    }
}
