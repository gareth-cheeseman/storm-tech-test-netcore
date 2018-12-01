using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Services
{
    public interface IGravatarUrl
    {
        string ProfileUrl(string hash);
        string ImageUrl(string hash, int size);
    }
}
