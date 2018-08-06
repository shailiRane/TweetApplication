using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TweetApplication.Business.Contracts
{
    [DataContract]
    public class TweetRequest
    {
        public TweetRequest()
        {

        }

        [DataMember(Name = "startDate ")]
        public string StartDate { get; set; }


        [DataMember(Name = "endDate")]
        public string EndDate { get; set; }
    }
}