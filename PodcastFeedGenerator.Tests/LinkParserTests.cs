using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using PodcastFeedGenerator.Models;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace PodcastFeedGenerator.Tests
{
    [UseReporter(typeof(DiffReporter))]
    [UseApprovalSubdirectory("Approvals")]
    public class LinkParserTests
    {
        private readonly string _testFilePath = @"..\..\Data\IE-2015-04-17.html";

        [Fact]
        private void should_grab_links()
        {
            var input = File.ReadAllText(_testFilePath);

            var linkGrabber = new LinkParser();
            var result = linkGrabber.Parse(input);

            Approvals.VerifyAll(result, "[name, link]");
        }
    }
}