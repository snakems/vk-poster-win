using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace vk_poster
{
    [DataContract]
    class VkApiResponsePhotosSaveWallPhoto : VkApiResponse
    {
        [DataMember]
        public VkApiResponseResult response { get; set; }

        // После успешного выполнения возвращает массив с загруженной фотографией,
        // возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created.
        // В случае наличия фотографий в высоком разрешении также будут возвращены адреса
        // с названиями src_xbig и src_xxbig.

        [DataContract]
        public class VkApiResponseResult
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public int pid { get; set; }
            [DataMember]
            public int aid { get; set; }
            [DataMember]
            public int owner_id { get; set; }
            [DataMember]
            public string src { get; set; }
            [DataMember]
            public string src_big { get; set; }
            [DataMember]
            public string src_small { get; set; }
            [DataMember]
            public int created { get; set; }
            [DataMember]
            public string src_xbig { get; set; }
            [DataMember]
            public string src_xxbig { get; set; }
        }
    }
}
