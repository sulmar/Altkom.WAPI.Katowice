using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Altkom.RentBikes.WebApiService.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            var result = ValidateKey(request);

            if (result)
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }

            return response;
        }

        private bool ValidateKey(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;

            if (request.Headers.TryGetValues("secret-key", out headerValues))
            {
                string secretkey = headerValues.First();

#if DEBUG
                Console.WriteLine("XXXXX");
#endif
                return secretkey == "1234";
            }

            return false;
        }
    }
}