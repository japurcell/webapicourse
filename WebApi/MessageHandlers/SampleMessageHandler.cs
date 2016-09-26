using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WebApi
{
    public class SampleMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("At request stage...");

            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine("At response stage...");

            return response;
        }
    }
}