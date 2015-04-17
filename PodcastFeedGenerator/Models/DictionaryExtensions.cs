using PodcastRssGenerator4DotNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodcastFeedGenerator.Models
{
    public static class DictionaryExtensions
    {
        public static List<Episode> ToEpisodes<TKey, TValue>(this Dictionary<string, string> dict)
        {
            return dict.Select(kvp => new Episode()
                {
                    Title = kvp.Key,
                    FileUrl = kvp.Value,
                    Summary = "In this first and short episode, I introduce myself, Keyvan.FM, and the type of content that I'm going to publish on this podcast.",
                    SubTitle = "In this first and short episode, I introduce myself, Keyvan.FM, and the type of content that I'm going to publish on this podcast.",
                    Permalink = "http://keyvan.fm/introduction",
                    FileType = "audio/mpeg",
                    FileLength = 4940509,
                    PublicationDate = DateTime.Parse("Tue, 13 Mar 2012 00:40:28 GMT"),
                    Duration = "00:05:06",
                    IsExplicit = false
                }).ToList();
        }
    }
}