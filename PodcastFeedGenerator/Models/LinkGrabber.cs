using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace PodcastFeedGenerator.Models
{
    public class LinkGrabber
    {
        public Dictionary<string, string> Grab(string inputHtml)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(inputHtml);

            return Grab(htmlDocument);
        }

        private Dictionary<string, string> Grab(HtmlDocument input)
        {
            var result = new Dictionary<string, string>();
            string ieXpath = ".//*[@id=\'colFirst-wide\']/div[3]/div[2]/ul/li[*]/span[2]/a";

            foreach (var node in input.DocumentNode.SelectNodes(ieXpath))
            {
                var link = JObject.Parse(node.Attributes["data-media"].Value)["file"].ToString();
                var description = node.InnerHtml;

                result[description] = link;
            }

            return result;
        }
    }
}