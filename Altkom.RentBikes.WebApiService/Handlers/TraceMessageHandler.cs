using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Altkom.RentBikes.WebApiService.Handlers
{
    public class TraceMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"{request.Method}: {request.RequestUri}");

            Debug.WriteLine(await request.Content.ReadAsStringAsync());

            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine(response.StatusCode);

            return response;
        }

    }
}