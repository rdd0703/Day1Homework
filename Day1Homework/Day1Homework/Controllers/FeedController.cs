using Day1Homework.CustomerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class FeedController : Controller
    {
        //private NorthwindEntities db = new NorthwindEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RssResult(feed);
        }
        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                "北風測試資料",
                "訂單RSS！",
                new Uri(Url.Action("Rss", "Feed", null, "http")));

            var items = new List<SyndicationItem>();


            for (int i = 0; i < 10; i++)
            {
                var item = new SyndicationItem(
                    "ShipName_"+i.ToString(),
                    "ShipAddress_"+i.ToString(),
                    new Uri(Url.Action("Detail", "Order", new { id = i }, "http")),
                    "ID",
                    DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}