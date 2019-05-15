using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterCloneMVCUI.Models;
using DataAccess;
namespace TwitterCloneMVCUI.Controllers
{
    [Authorize]
    public class TwitterController : Controller
    {
        // GET: Twitter
       
        public ActionResult Home()
        {
            
            var repository = new TweetRepository();
            var objTweets = repository.GetAllTweets();
            var tweetModel = new List<TweetsViewModel>();
            foreach (var item in objTweets)
            {
                tweetModel.Add(new TweetsViewModel { user_id = item.Useridd, tweet_id = item.tweet_id, message = item.usermessage, created = item.created });
            }
            return View(tweetModel);
        }

        public ActionResult Tweet()
        {
            return View();
        }


        [HttpPost,ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Tweet(TweetsViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                var objTweet = new Tweet();
                objTweet.usermessage = objModel.message;
                objTweet.created = DateTime.Now;
                objTweet.Useridd = User.Identity.Name;


                var tRep = new TweetRepository();
                tRep.AddTweet(objTweet);

                ViewBag.msg = "Tweeted!!";
            }
            return View(objModel);
        }

        public ActionResult MyProfile()
        {
            string userID = User.Identity.Name;
            var repository = new TweetRepository();
            var objTweets= repository.GetTweetsByName(userID);
            var tweetModel = new List<TweetsViewModel>();
            foreach (var item in objTweets)
            {
                tweetModel.Add(new TweetsViewModel { user_id = item.Useridd, tweet_id = item.tweet_id, message = item.usermessage, created = item.created });
            }
            return View(tweetModel);
        }

        public ActionResult EditTweet(int id)
        {
            var repository = new TweetRepository();
            var tweetObj= repository.FindTweet(id);
            var tweetModel = new TweetsViewModel {user_id=tweetObj.Useridd, tweet_id = tweetObj.tweet_id, message=tweetObj.usermessage, created=tweetObj.created };
            return View(tweetModel);
        }

        [HttpPost, ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult EditTweet(TweetsViewModel objTweetModel)
        {
            if (ModelState.IsValid)
            {
                var objTweet = new Tweet();
                objTweet.usermessage = objTweetModel.message;
                objTweet.created = DateTime.Now;
                objTweet.Useridd = User.Identity.Name;
                objTweet.tweet_id = objTweetModel.tweet_id;

                var tRep = new TweetRepository();
                tRep.EditTweet(objTweet);
                ViewBag.msg = "Editted Successfully";
            }
            else
            {
                ViewBag.msg = "Error";
                
            }
            return View(objTweetModel);
        }


        public ActionResult DeleteTweet(int id)
        {

            var repository = new TweetRepository();
             repository.DeleteTweet(id);
            return RedirectToAction("MyProfile", "Twitter"); 
        }
    }
}