using System;
using System.Buffers.Text;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Todo.Services
{
    public  class Gravatar : IGravatar
    {
        private IGravatarUrl _gravatarUrl;
        private HttpClient _client;

        public Gravatar(IGravatarUrl gravatarUrl)
        {
            _gravatarUrl = gravatarUrl;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "C# app");
        }
        
        public  async Task<string> GetGravatarName(string hash)
        {
            var profile = await GetProfileJson(hash);
            return profile.Entry[0].displayName;

        }

        public async Task<string> GetGravatarImage(string hash)
        {
            var url = _gravatarUrl.ImageUrl(hash, 30);
            var result = await _client.GetByteArrayAsync(url);
            return "data:image/png;base64," + Convert.ToBase64String(result);
            
        }


        public async Task<GravatarResponse> GetProfileJson(string hash)
        {
            var url = _gravatarUrl.ProfileUrl(hash);
            var result = await _client.GetStringAsync(url);
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

        public string GetHash(string emailAddress)
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