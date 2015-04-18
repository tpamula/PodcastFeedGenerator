using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PodcastFeedGenerator.Models
{
    public class LinkGrabber
    {
        private readonly string _informatorEkonomicznyUrl = "http://www.polskieradio.pl/9/Audycja/7418";

        public Dictionary<string, string> Grab()
        {
            var websiteHtml = Task.Run(() => FetchWebsite()).Result;
            var linkParser = new LinkParser();
            var result = linkParser.Parse(websiteHtml);

            return result;
        }

        public async Task<string> FetchWebsite()
        {
            string websiteHtml;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_informatorEkonomicznyUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException("Invalid status code.");
                }

                websiteHtml = await response.Content.ReadAsStringAsync();
            }
            return websiteHtml;
        }
    }
}