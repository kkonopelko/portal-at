using Polly;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Portal.Automation.Api.Clients
{
    public class BaseClient : IDisposable
    {
        private readonly RestClient _restClient;
        private readonly HttpClientHandler _httpClientHandler;
        private bool _disposedValue;

        protected BaseClient()
        {
            _httpClientHandler = new HttpClientHandler();
            var httpClient = new HttpClient(_httpClientHandler);

            _restClient = new RestClient(httpClient, new RestClientOptions(ApiUrl.BaseApiUrl));
        }

        ~BaseClient()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return ExecuteWithRetryAsync(async () =>
            {
                var response = await _restClient.ExecuteAsync(request);
                return response;
            });
        }

        public Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request)
        {
            return ExecuteWithRetryAsync(async () =>
            {
                var response = await _restClient.ExecuteAsync<T>(request);
                return response;
            });
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                _httpClientHandler.Dispose();
                _restClient.Dispose();
                _disposedValue = true;
            }
        }

        private Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> executeFn)
        {
            var retryPolicy = Policy
                 .Handle<Exception>()
                 .WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(2000));

            return retryPolicy.ExecuteAsync(executeFn);
        }
    }
}
