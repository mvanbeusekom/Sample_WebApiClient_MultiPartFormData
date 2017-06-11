using System;

using UIKit;
using System.Net.Http;
using Xablu.WebApiClient;
using System.Net.Http.Headers;
using Foundation;
using System.Runtime.InteropServices;
using Fusillade;
using System.Threading.Tasks;

namespace WebApiUpload
{
    public partial class ViewController : UIViewController
    {
        private readonly IWebApiClient _webApiClient = new WebApiClient("https://posttestserver.com", () => new NSUrlSessionHandler());

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            buttonUpload.TouchUpInside += async (sender, e) => {
                 await UploadFile();
            };
        }

        private async Task UploadFile()
        {
            var byteArray = LoadImage();
            var payload = new Payload { Image = byteArray, Description = "Test description", Title = "Test" };

            _webApiClient.HttpContentResolver = new MultipartFormDataResolver();
            _webApiClient.HttpResponseResolver = new SimpleStringResponseResolver();
		
            try
            {
                // Files are uploaded to a public test server, more info here: http://posttestserver.com
                var response = await _webApiClient.PostAsync<Payload, string>(Priority.Explicit, "post.php?dir=webapiclient", payload, null);
                resultTextView.Text = response;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private byte[] LoadImage()
        {
            var image = UIImage.FromBundle("image");
            using (var imageData = image.AsPNG())
            {
                var imageByteArray = new Byte[imageData.Length];
                Marshal.Copy(imageData.Bytes, imageByteArray, 0, Convert.ToInt32(imageData.Length));

                return imageByteArray;
            }
        }
    }
}
