using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TweetRepository
    {
        public void AddTweet(Tweet objTweet)
        {
            try
            {
                using (TwitterContext objContext = new TwitterContext())
                {
                    objContext.TWEETs.Add(objTweet);
                    objContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tweet> GetTweetsByName(string userid)
        {
            List<Tweet> objTweets = new List<Tweet>();
            try
            {
                using (TwitterContext objContext = new TwitterContext())
                {
                    var Tweets = from obj in objContext.TWEETs
                                 where obj.Useridd == userid
                                 select obj;
                    foreach(var item in Tweets)
                    {
                        objTweets.Add(new Tweet {Useridd = item.Useridd, tweet_id = item.tweet_id, usermessage = item.usermessage, created = item.created});
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tweet> GetAllTweets()
        {
            List<Tweet> objTweets = new List<Tweet>();
            try
            {
                using (TwitterContext objContext = new TwitterContext())
                {
                    var tweets = from obj in objContext.TWEETs
                                 
                                 select obj;
                    foreach (var item in tweets)
                    {
                        objTweets.Add(new Tweet { Useridd = item.Useridd, tweet_id = item.tweet_id, usermessage = item.usermessage, created = item.created });
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditTweet(Tweet objTweet)
        {
            try
            {
                using (TwitterContext objContext = new TwitterContext())
                {

                    objContext.TWEETs.Attach(objTweet);
                    objContext.Entry(objTweet).State = System.Data.Entity.EntityState.Modified;
                    objContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTweet(int id)
        {
            try
            {
                using (TwitterContext objContext = new TwitterContext())
                {
                    var query = (from obj in objContext.TWEETs
                                where obj.tweet_id == id
                                select obj).FirstOrDefault();
                    objContext.TWEETs.Remove(query);
                    objContext.SaveChanges();

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tweet FindTweet(int id)
        {
            try
            {
                using (TwitterContext objContext = new TwitterContext())
                {
                    var query = (from obj in objContext.TWEETs
                                 where obj.tweet_id == id
                                 select obj).FirstOrDefault();
                    return query;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
