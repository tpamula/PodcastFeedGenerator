using PodcastFeedGenerator.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace PodcastFeedGenerator.Controllers
{
    public class InformatorEkonomicznyController : Controller
    {
        // GET: InformatorEkonomiczny
        public ActionResult Index()
        {
            Response.ContentType = "application/rss+xml";
            var settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            var xmlWriter = XmlWriter.Create(Response.Output, settings);
            var ieRssGenerator = new InformatorEkonomicznyRssStreamWriter();
            var linkGrabber = new LinkGrabber();

            var linksDictionary = linkGrabber.Grab();
            var episodes = linksDictionary.ToEpisodes().ToList();
            ieRssGenerator.Write(episodes, xmlWriter);

            Response.End();
            return new EmptyResult();
        }
    }
}