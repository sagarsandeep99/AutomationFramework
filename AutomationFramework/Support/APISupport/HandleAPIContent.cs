using Newtonsoft.Json;
using RestSharp;

namespace AutomationFramework.Support.APISupport
{
    public class HandleAPIContent
    {
        public static T GetContent<T>(RestResponse response) where T : class
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static T ParseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}
