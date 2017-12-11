using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntApps.Samples.HttpCore
{
    public static class HttpContentExtensions
    {
        // this is missing from core 2.0 as of now, this method was in core 1...
        //  http://nodogmablog.bryanhogan.net/2017/10/httpcontent-readasasync-with-net-core-2/

        public static async Task<T> ReadAsAsync<T> (this HttpContent content)
        {
            string json = await content.ReadAsStringAsync ();
            T value = JsonConvert.DeserializeObject<T> (json);
            return value;
        }
    }
}