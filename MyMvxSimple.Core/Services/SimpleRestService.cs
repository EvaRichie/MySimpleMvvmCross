using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public class SimpleRestService : ISimpleRestService
    {
        private readonly IMvxJsonConverter _jsonCvt;

        public SimpleRestService(IMvxJsonConverter jsonCvt)
        {
            _jsonCvt = jsonCvt;
        }

        public void MakeRequest<T>(string requestUrl, string verb, Action<T> success, Action<Exception> error)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = verb;
            request.Accept = "application/json";
            MakeRequest(request,
                (response) =>
             {
                 if (success != null)
                 {
                     T result;
                     try
                     {
                         result = Deserialize<T>(response);
                     }
                     catch (Exception ex)
                     {
                         error(ex);
                         return;
                     }
                     success(result);
                 }
             },
             (errorResponse) =>
             {
                 if (error != null)
                 {
                     error(errorResponse);
                 }
             });
        }

        private void MakeRequest(HttpWebRequest request, Action<string> success, Action<Exception> error)
        {
            request.BeginGetResponse(token =>
            {
                try
                {
                    using (var response = request.EndGetResponse(token))
                    using (var stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream);
                        success(reader.ReadToEnd());
                    }
                }
                catch (WebException wEx)
                {
                    error(wEx);
                }
                catch (Exception ex)
                {
                    error(ex);
                }
            }, null);
        }

        private T Deserialize<T>(string responseBody)
        {
            return _jsonCvt.DeserializeObject<T>(responseBody);
        }
    }
}
