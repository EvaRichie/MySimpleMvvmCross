using ModernHttpClient;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IMvxJsonConverter _jsonCvt;

        public HttpClientService(IMvxJsonConverter jsonCvt)
        {
            _jsonCvt = jsonCvt;
        }

        //public async Task<T> DownloadAsStringAsync<T>(string requestUriString, Action<T> success, Action<Exception> error)
        //{
        //    T result = default(T);
        //    try
        //    {
        //        using (var httpClient = new HttpClient(new NativeMessageHandler()))
        //        using (var response = await httpClient.GetAsync(requestUriString))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            var resultStr = await response.Content.ReadAsStringAsync();
        //            result = Deserialize<T>(resultStr);
        //            //if (success != null)
        //            //{
        //            //    var result = Deserialize<T>(resultStr);
        //            //    success(result);
        //            //}
        //            return result;
        //        }
        //    }
        //    catch (HttpRequestException httpEx)
        //    {
        //        //error(httpEx);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        //error(ex);
        //        return result;
        //    }
        //}

        public async void DownloadAsStringAsync<T>(string requestUriString, Action<T> success, Action<Exception> error)
        {
            try
            {
                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                using (var response = await httpClient.GetAsync(requestUriString))
                {
                    response.EnsureSuccessStatusCode();
                    var resultStr = await response.Content.ReadAsStringAsync();
                    if (success != null)
                    {
                        var result = Deserialize<T>(resultStr);
                        success(result);
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                error(httpEx);
            }
            catch (Exception ex)
            {
                error(ex);
            }
        }

        private T Deserialize<T>(string responseBody)
        {
            return _jsonCvt.DeserializeObject<T>(responseBody);
        }
    }
}
