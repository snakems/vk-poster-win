using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace vk_poster
{
    [DataContract]
    public abstract class VkApiResponse
    {
        [DataMember]
        public VkApiError error { get; set; }

        [DataContract]
        public class VkApiError
        {
            [DataMember]
            public int error_code { get; set; }
            [DataMember]
            public string error_msg { get; set; }
            [DataMember]
            public string captcha_sid { get; set; }
            [DataMember]
            public string captcha_img { get; set; }
            [DataMember]
            public VkApiErrorRequestParams[] request_params { get; set; }

            [DataContract]
            public class VkApiErrorRequestParams
            {
                [DataMember]
                public string key { get; set; }
                [DataMember]
                public string value { get; set; }
            }
        }
    }
}
