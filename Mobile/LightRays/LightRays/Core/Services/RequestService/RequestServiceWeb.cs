using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LightRays.Core.Services
{
    public class RequestServiceWeb : IRequestService
    {
        public async Task<bool> GetRequest(string uri, string code)
        {
            try
            {
                await Task.Run(() => 
                {
                    WebRequest request = WebRequest.Create(string.Format("http://{0}/effect?code={1}", uri, code));
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    HttpWebResponse response = null;
                    response = (HttpWebResponse)request.GetResponse();

                    string jsonData;
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(stream);
                        jsonData = sr.ReadToEnd();
                        sr.Close();
                    }

                });

                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
