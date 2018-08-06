using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TweetApplication.Business.Contracts
{
    [DataContract(Name ="Tweet")]
    public class Tweet
    {
        public Tweet()
        {

        }

        [DataMember(Name ="id")]
        public string Id;

        [DataMember(Name ="stamp")]
        public string Stamp;

        [DataMember(Name = "text")]
        public string Text;
    }
}