using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DropNet.Models
{
    [Serializable()] public class AccountInfo : ISerializable
    {
        public string referral_link { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string display_name { get; set; }
        public QuotaInfo quota_info { get; set; }
        public long uid { get; set; }

        /// <summary>
        /// Serialization Function
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {            
            info.AddValue("rl", referral_link);
            info.AddValue("c", country);
            info.AddValue("e", email);
            info.AddValue("dn", display_name);
            info.AddValue("qi", quota_info);
            info.AddValue("uid", uid);
        }

        /// <summary>
        /// Deserialization Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public AccountInfo(SerializationInfo info, StreamingContext ctxt)
        {       
            referral_link = (string)info.GetValue("rl", typeof(string));
            country = (string)info.GetValue("c", typeof(string));
            email = (string)info.GetValue("e", typeof(string));
            display_name = (string)info.GetValue("dn", typeof(string));
            quota_info = (QuotaInfo)info.GetValue("qi", typeof(QuotaInfo));
            uid = (long)info.GetValue("uid", typeof(long));        
        }

        /// <summary>
        /// Generic Constructor. Provided to facilitate construction, since once a constructor is provided (in this case, for deserialization), the default construction is no longer presumed.
        /// </summary>
        public AccountInfo() { }
    }//[AccountInfo] Class

    [Serializable()] public class QuotaInfo : ISerializable
    {
        public long shared { get; set; }
        public long quota { get; set; }
        public long normal { get; set; }

        /// <summary>
        /// Serialization Function
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {            
            info.AddValue("s", shared);
            info.AddValue("q", quota);
            info.AddValue("n", normal);
        }

        /// <summary>
        /// Deserialization Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public QuotaInfo(SerializationInfo info, StreamingContext ctxt)
        {       
            shared = (long)info.GetValue("s", typeof(long));        
            quota = (long)info.GetValue("q", typeof(long));        
            normal = (long)info.GetValue("n", typeof(long));        
        }

        /// <summary>
        /// Default Constructor. Must be explicit once any other constructor is provided.
        /// </summary>
        public QuotaInfo() { }
    }
}
