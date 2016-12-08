using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Altkom.RentBikes.WebApiService.Formatters
{
    public class QrCodeMediaTypeFormatter : MediaTypeFormatter
    {
        public QrCodeMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("image/png"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Bike);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var bike = value as Bike;

            var uri = $"http://chart.apis.google.com/chart?cht=qr&chs=300x300&chl={HttpUtility.UrlEncode(bike.Number)}";

            using (var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync(uri);

                writeStream.Write(data, 0, data.Length);
            }

        }
    }
}