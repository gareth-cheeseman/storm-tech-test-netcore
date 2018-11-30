using System;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Todo.TagHelpers;

namespace Todo.Services
{
    public  class Gravatar : IGravatar
    {
        
        public  async Task<string> GetGravatarName(string hash)
        {
            var profile = await GetProfileJson(hash);
            return profile.Entry[0].displayName;

        }


        public async Task<GravatarResponse> GetProfileJson(string hash)
        {
            var url = $"https://www.gravatar.com/{hash}.json";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# app");
            var result = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<GravatarResponse>(result);
        }

        
        public class GravatarResponse
        {
            public GravatarEntry[] Entry { get; set; }
        }

        public class GravatarEntry
        {
            public string id { get; set; }
            public string hash { get; set; }
            public string requestHash { get; set; }
            public string profileUrl { get; set; }
            public string preferredUsername { get; set; }
            public string thumbnailUrl { get; set; }
            public GravatarPhoto[] photos { get; set; }
            public object[] name { get; set; }
            public string displayName { get; set; }
            public object[] urls { get; set; }
        }

        public class GravatarPhoto
        {
            public string value { get; set; }
            public string type { get; set; }
        }

        public static string GetHash(string emailAddress)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.Default.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }
    }
}