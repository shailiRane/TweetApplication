using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TweetApplication.Business.Contracts;


namespace TweetApplication.Business
{
    public class TweetClient : ITweetClient
    {
        public async Task<List<Business.Contracts.Tweet>> GetTweetInfo(DateTime startDate, DateTime endDate)
        {
            List<Business.Contracts.Tweet> response = new List<Business.Contracts.Tweet>();
            try
            {
                TweetRequest tweetRequest = new TweetRequest();
                tweetRequest.StartDate = startDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
                tweetRequest.EndDate = endDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

                using (HttpClientWrapper httpClient = new HttpClientWrapper("https://badapi.iqvia.io/api/v1/Tweets", string.Format("?startDate={0}&endDate={1}", tweetRequest.StartDate,tweetRequest.EndDate), "application/json"))
                {
                    response = await httpClient.GetData<Business.Contracts.Tweet>();
                }
            }
            catch (Exception exception)
            {

            }

            return response;
        }
    }
}