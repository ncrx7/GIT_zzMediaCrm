using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace zzMedya.Shared
{
    public static class RestHelper
    {
        private static readonly string baseURL = "https://localhost:44380/api/";
        public static async Task<string> GetALL()
        {
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage res = await client.GetAsync(baseURL + "Customer"))
                {
                    using (HttpContent content = res.Content )
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string BeautifyJson(string jsonStr)
        {
            JToken parseJson = JToken.Parse(jsonStr);
            return parseJson.ToString(Formatting.Indented);
        }

        public static async Task<string> Get(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "users/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Post(string id, string name, string job)
        {
            using (HttpClient client = new HttpClient())
            {
                var inputData = new Dictionary<string, string>()
                {
                    { "id", id },
                    { "name", name },
                    { "job", job}
                };
                var input = new FormUrlEncodedContent(inputData);
                using (HttpResponseMessage res = await client.PostAsync(baseURL + "users" , input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> PUT(string id, string name, string job)
        {
            using (HttpClient client = new HttpClient())
            {
                var inputData = new Dictionary<string, string>()
                {
                    { "name", name },
                    { "job", job}
                };
                var input = new FormUrlEncodedContent(inputData);
                using (HttpResponseMessage res = await client.PutAsync(baseURL + "users/" + id, input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
