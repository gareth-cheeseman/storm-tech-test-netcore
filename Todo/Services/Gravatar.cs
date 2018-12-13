using System;
using System.Buffers.Text;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Todo.Services
{
    public  class Gravatar : IGravatar
    {
        private IGravatarUrl gravatarUrl;
        private IRestClient client;

        public Gravatar(IGravatarUrl gravatarUrl, IRestClient client)
        {
            this.gravatarUrl = gravatarUrl;
            this.client = client;
            this.client.UserAgent = "C# app";
            this.client.BaseUrl = new Uri("https://gravatar.com");
            this.client.Timeout = 1000;
        }

        public async Task<string> GetGravatarName(string hash)
        {
            var profile = await GetProfileJson(hash);
            return profile == null ?  "Gravatar unavailable" : profile.Entry[0].displayName;
        }

        public async Task<string> GetGravatarImage(string hash)
        {
            var url = gravatarUrl.ImageUrl(hash, 30);
            var restRequest = new RestRequest {Resource = url};
            var result = await client.ExecuteTaskAsync(restRequest);
            if (result.IsSuccessful)
            {
                return "data:image/png;base64," + Convert.ToBase64String(result.RawBytes);
            }

            var data = "./wwwroot/images/DefaultProfile.png".ReadImageFile();
            return "data:image/png;base64," + Convert.ToBase64String(data);
        }


        public async Task<GravatarResponse> GetProfileJson(string hash)
        {
            var url = gravatarUrl.ProfileUrl(hash);
            var restRequest = new RestRequest {Resource = url};
            var result = await client.ExecuteTaskAsync(restRequest);
            if (!result.IsSuccessful)
            {
                result = await client.ExecuteTaskAsync(restRequest);
            }
            
            if (result.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<GravatarResponse>(result.Content);

            }

            return null;
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