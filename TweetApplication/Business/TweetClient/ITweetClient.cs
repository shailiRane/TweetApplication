using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetApplication.Business
{
    public interface ITweetClient
    {
        Task<List<Business.Contracts.Tweet>> GetTweetInfo(DateTime startDate, DateTime endDate);
    }
}