using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace vk_poster
{
    [DataContract]
    class VkApiResponsePhotosGetUploadServer : VkApiResponse
    {
        [DataMember]
        public VkApiResponseResult response { get; set; }

        // upload_url — адрес для загрузки фотографий;
        // aid — идентификатор альбома, в который будет загружена фотография;
        // mid — идентификатор пользователя, от чьего имени будет загружено фото.

        [DataContract]
        public class VkApiResponseResult
        {
            [DataMember]
            public string upload_url { get; set; }
            [DataMember]
            public int aid { get; set; }
            [DataMember]
            public int mid { get; set; }
        }
    }
}
