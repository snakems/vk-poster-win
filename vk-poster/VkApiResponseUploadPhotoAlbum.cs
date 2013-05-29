using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace vk_poster
{
    [DataContract]
    class VkApiResponseUploadPhotoAlbum : VkApiResponse
    {
        [DataMember]
        public VkApiResponseResult response { get; set; }

        // Ответ сервера всегда приходит в формате JSON, а поля server, photos_list, aid и hash в нем содержат строки,
        // внутренний формат которых может изменяться со временем.
        // В частности, строка photos_list может содержать другой json-объект, который не следует декодировать,
        // разбирать на части или иным образом модифицировать.

        [DataContract]
        public class VkApiResponseResult
        {
            [DataMember]
            public int aid { get; set; }
            [DataMember]
            public string server { get; set; }
            [DataMember]
            public string photos_list { get; set; }
            [DataMember]
            public string hash { get; set; }
        }
    }
}
