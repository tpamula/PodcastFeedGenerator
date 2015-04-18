using PodcastFeedGenerator.Models.RssStreamWriter;
using System;
using System.Collections.Generic;
using System.Xml;

namespace PodcastFeedGenerator.Models
{
    public class InformatorEkonomicznyRssStreamWriter
    {
        public void Write(List<Episode> episodes, XmlWriter writer)
        {
            RssStreamWriter.RssStreamWriter streamWriter = new RssStreamWriter.RssStreamWriter
            {
                Title = "Informator Ekonomiczny - Trójka",
                ImageUrl = "http://i.imgur.com/U0FmOCr.jpg"
            };

            streamWriter.Episodes = episodes;

            streamWriter.Write(writer);
        }
    }
}