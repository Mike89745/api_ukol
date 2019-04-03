using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPF_API
{
    public class API
    {
        static HttpClient client = new HttpClient();
        public async Task<List<Post>> LoadPosts()
        {
            List<Post> Posts = new List<Post>();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                Posts = JsonConvert.DeserializeObject<List<Post>>(await response.Content.ReadAsStringAsync());
            }
            return Posts;
        }
    }
}