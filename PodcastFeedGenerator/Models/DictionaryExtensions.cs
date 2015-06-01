using PodcastFeedGenerator.Models.RssStreamWriter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PodcastFeedGenerator.Models
{
    public static class DictionaryExtensions
    {
        public static List<Episode> ToEpisodes(this Dictionary<string, string> dict)
        {
            var result = new List<Episode>();

            foreach (var kvp in dict)
            {
                var episodeLocalPublicationDate = DateTime.ParseExact(
                    kvp.Key.Substring("Informator ekonomiczny ".Count()),
                    "dd.MM.yyyy HH:mm",
                    CultureInfo.InvariantCulture);

                TimeZoneInfo cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
                var episodeGmtPublicationDate = cetTimeZone.IsDaylightSavingTime(episodeLocalPublicationDate)
                    ? episodeLocalPublicationDate.AddHours(-2)
                    : episodeLocalPublicationDate.AddHours(-1);

                var episode = new Episode()
                {
                    Title = kvp.Key,
                    FileUrl = kvp.Value,
                    PublicationDate = episodeGmtPublicationDate
                };

                result.Add(episode);
            }

            return result;
        }
    }
}