﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace vk_poster
{
    [DataContract]
    class VkApiResponsePhotosGetWallUploadServer : VkApiResponse
    {
        [DataMember]
        public VkApiResponseResult response { get; set; }

        [DataContract]
        public class VkApiResponseResult
        {
            [DataMember]
            public string upload_url { get; set; }
        }
    }
}
