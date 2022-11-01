using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShoperCsvParser
{
    internal class ImageParser
    {
        private readonly HttpClient webClient;
        public ImageParser()
        {
            webClient = new HttpClient();
        }

        public async Task<byte[]> GetImage(string url)
        {
            using (var client = new HttpClient())
            {
                using var response = await client.GetAsync(url);
                    return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            }
        }

    }
}
