using System.Collections.Generic;

namespace PodcastFeedGenerator.Models.RssStreamWriter
{
    public partial class RssStreamWriter
    {
        public string AuthorEmail { get; set; }

        public string AuthorName { get; set; }

        public List<string> Categories { get; set; }

        public string Copyright { get; set; }

        public string Description { get; set; }

        public List<Episode> Episodes { get; set; }

        public string HomepageUrl { get; set; }

        public int ImageHeight { get; set; }

        public string ImageUrl { get; set; }

        public int ImageWidth { get; set; }

        public bool IsExplicit { get; set; }

        public string iTunesCategory { get; set; }

        public string iTunesSubCategory { get; set; }

        public string Language { get; set; }

        public string SubTitle { get; set; }

        public string Title { get; set; }
    }
}