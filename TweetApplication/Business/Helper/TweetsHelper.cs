using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Business.Contracts;

namespace TweetApplication.Business.Helper
{
    public class TweetsHelper
    {
        public static List<Tweet> tweetList = new List<Tweet>();
        public static DateTime startDate = DateTime.UtcNow.AddYears(-2).ToUniversalTime();
        public static DateTime endDate = DateTime.UtcNow.AddYears(-1).ToUniversalTime();


        public async Task<List<Tweet>> GetTweets()
        {
            ITweetClient tweetClient = new TweetClient();
            var response = await tweetClient.GetTweetInfo(startDate, endDate);
            return response;
        }
        public async Task<List<Tweet>> FetchAndProcessTweets()
        {
            var tweets = await GetTweets();
            DateTime oldStartDate = default(DateTime);
            while (tweets.Count() > 0)
            {
                tweetList.AddRange(tweets);
                oldStartDate = startDate;
                startDate = Convert.ToDateTime(tweetList.Max(tweet => tweet.Stamp)).ToUniversalTime();
                if (oldStartDate == startDate) break;
                tweets = await GetTweets();
            }
            tweetList = tweetList.GroupBy(tweet => tweet.Id).Select(y => y.First()).ToList();
            return tweetList;
        }

    }
}