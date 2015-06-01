using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PodcastFeedGenerator.Models
{
    public class LinkParser
    {
        public Dictionary<string, string> Parse(string inputHtml)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(inputHtml);

            return Parse(htmlDocument);
        }

        private Dictionary<string, string> Parse(HtmlDocument input)
        {
            var result = new Dictionary<string, string>();
            string linksXpath = "//div[span[@data-media] and @class='positioner']";

            foreach (var node in input.DocumentNode.SelectNodes(linksXpath))
            {
                var linkNode = node.SelectSingleNode(".//span[@data-media]");
                var link = JObject.Parse(linkNode.Attributes["data-media"].Value)["file"].ToString();

                var descriptionNode = node.SelectSingleNode(".//span[@class='title']");
                var description = descriptionNode.InnerHtml;
                Regex.Replace(description, @"\r\n?|\n", "");
                description = description.Trim();

                result[description] = link;
            }

            return result;
        }
    }
}