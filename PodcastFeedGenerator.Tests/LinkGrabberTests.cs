using PodcastFeedGenerator.Models;
using System.Threading.Tasks;
using Xunit;

namespace PodcastFeedGenerator.Tests
{
    public class LinkGrabberTests
    {
        /// <summary>
        /// the motivation for this test is that the LinkGrabber
        /// throws an exception when httpStatuCode is different than OK
        /// </summary>
        [Fact]
        private async Task fetches_website()
        {
            var linkGrabber = new LinkGrabber();
            var result = await linkGrabber.FetchWebsite();

            Assert.True(!string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        private void grabs_links_from_website()
        {
            var linkGrabber = new LinkGrabber();
            var result = linkGrabber.Grab();

            Assert.NotEmpty(result);
        }
    }
}