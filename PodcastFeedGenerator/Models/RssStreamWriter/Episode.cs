using System;

namespace PodcastFeedGenerator.Models.RssStreamWriter
{
    public class Episode
    {
        public string Duration { get; set; }

        public int FileLength { get; set; }

        public string FileType { get; set; }

        public string FileUrl { get; set; }

        public bool IsExplicit { get; set; }

        public string Keywords { get; set; }

        public string Permalink { get; set; }

        public DateTime PublicationDate { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string Title { get; set; }
    }
}