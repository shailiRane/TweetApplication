using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace TweetApplication.Business
{
    internal class HttpClientWrapper : IDisposable
    {
        private HttpClient httpClient = null;
        private WebRequestHandler webRequestHandler = null;
        private string relativePath;

        internal HttpClientWrapper(string baseAddress, string relativePath, string contentType)
        {
            if (string.IsNullOrEmpty(baseAddress) == true)
            {
                throw new ArgumentNullException("baseAddress");
            }

            if (string.IsNullOrEmpty(relativePath) == true)
            {
                throw new ArgumentNullException("relativePath");
            }
            this.SetHttpClient(baseAddress, contentType);
            this.relativePath = relativePath;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
                this.httpClient = null;
            }

            if (this.webRequestHandler != null)
            {
                this.webRequestHandler.Dispose();
                this.webRequestHandler = null;
            }
        }

        internal async Task<List<TResponse>> GetData<TResponse>()
         where TResponse : new()
        {
            List<TResponse> serviceResponse = await this.ProcessGetData<TResponse>();
            return serviceResponse;
        }


        private async Task<List<TResponse>> ProcessGetData<TResponse>()
            where TResponse : new()
        {
            List<TResponse> serviceResponse = new List<TResponse>();

            try
            {
                using (HttpResponseMessage responseMessage = await this.httpClient.GetAsync(this.relativePath))
                {
                    if (responseMessage != null)
                    {

                        if (responseMessage.IsSuccessStatusCode == true)
                        {
                            serviceResponse = await responseMessage.Content.ReadAsAsync<List<TResponse>>();
                        }
                    }
                    else
                    {
                       
                    }
                }
            }
            catch (Exception exception)
            {
            }

            return serviceResponse;
        }

        private void SetHttpClient(string baseAddress, string contentType)
        {
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            this.httpClient.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en-US"));
            this.httpClient.DefaultRequestHeaders.Add("Connection", "close");
            this.httpClient.BaseAddress = new Uri(baseAddress);
        }

    }
}
