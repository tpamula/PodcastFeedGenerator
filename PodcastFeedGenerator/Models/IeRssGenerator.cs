using PodcastRssGenerator4DotNet;
using System;
using System.Collections.Generic;
using System.Xml;

namespace PodcastFeedGenerator.Models
{
    public class IeRssGenerator
    {
        /// <summary>
        /// RssGenerator usage based on https://github.com/keyvan/PodcastRssGenerator4DotNet/blob/master/PodcastRssGenerator4DotNet/PodcastRssGenerator4DotNet.Test/Default.aspx.cs
        /// </summary>
        /// <param name="episodes"></param>
        /// <param name="writer">method modifies this parameter</param>
        public void Generate(List<Episode> episodes, XmlWriter writer)
        {
            RssGenerator generator = new RssGenerator();
            generator.Title = "Keyvan.FM";
            generator.SubTitle = generator.Description = "The online podcast channel of Keyvan Nayyeri.";
            generator.HomepageUrl = "http://keyvan.fm";
            generator.AuthorName = "Keyvan Nayyeri";
            generator.AuthorEmail = "i@keyvan.fm";
            generator.Language = "en-us";
            generator.Copyright = string.Format("Copyright {0} Keyvan Nayyeri. All rights reserved.", DateTime.UtcNow.Year);
            generator.ImageUrl = "http://keyvan.fm/content/images/feed-logo.png";
            generator.IsExplicit = false;
            generator.iTunesCategory = "Technology";
            generator.iTunesSubCategory = "Software How-To";

            episodes[0].FileLength = 1;
            generator.Episodes = episodes;

            generator.Generate(writer);
        }
    }
}