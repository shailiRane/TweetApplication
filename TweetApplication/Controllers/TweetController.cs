using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TweetApplication.Business.Helper;

namespace TweetApplication.Controllers
{
    public class TweetController : Controller
    {
        // GET: Tweet
        public async Task<ActionResult> TweetDetails()
        {
            TweetsHelper helper = new TweetsHelper();
            var tweetList = await helper.FetchAndProcessTweets();
            return View(tweetList);
        }

        // GET: Tweet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tweet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tweet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tweet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tweet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tweet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tweet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
