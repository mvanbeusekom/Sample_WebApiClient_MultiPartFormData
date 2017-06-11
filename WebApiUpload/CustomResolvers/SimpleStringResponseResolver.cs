using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xablu.WebApiClient;

namespace WebApiUpload
{
    public class SimpleStringResponseResolver
        : IHttpResponseResolver
    {
        public async Task<TResult> ResolveHttpResponseAsync<TResult>(HttpResponseMessage responseMessage)
        {
            var resultString = await responseMessage.Content.ReadAsStringAsync();

            return (TResult)Convert.ChangeType(resultString, typeof(TResult));
        }
    }
}
