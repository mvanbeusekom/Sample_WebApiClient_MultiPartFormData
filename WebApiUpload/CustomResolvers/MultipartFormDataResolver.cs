using System.Net.Http;
using System.Net.Http.Headers;
using Xablu.WebApiClient;

namespace WebApiUpload
{
    public class Payload
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }

    public class MultipartFormDataResolver
        : IHttpContentResolver
    {
        public HttpContent ResolveHttpContent<TContent>(TContent content)
        {
            var payload = content as Payload;

			var fileContent = new ByteArrayContent(payload.Image);

			fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
			fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
			{
				Name = "media[file]",
				FileName = "\"splash.png\""
			};

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new StringContent(payload.Title), "Title"); 
            multipartContent.Add(new StringContent(payload.Description), "Description");
            multipartContent.Add(fileContent);

            return multipartContent;
        }
    }
}
