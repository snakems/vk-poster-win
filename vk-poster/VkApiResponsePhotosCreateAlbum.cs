using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace vk_poster
{
    [DataContract]
    class VkApiResponsePhotosCreateAlbum : VkApiResponse
    {
        [DataMember]
        public VkApiResponseResult response { get; set; }

        //aid — идентификатор созданного альбома;
        //thumb_id — идентификатор фотографии, которая является обложкой альбома;
        //owner_id идентификатор пользователя или сообщества, которому принадлежит альбом;
        //title— название альбома;
        //description — описание альбома;
        //created — дата создания альбома в формате unixtime;
        //updated — дата обновления альбома в формате unixtime;
        //size — количество фотографий в альбоме;
        //privacy — настройки приватности для просмотра альбома;
        //comment_privacy — настройки приватности для комментирования альбома.

        [DataContract]
        public class VkApiResponseResult
        {
            [DataMember]
            public int aid { get; set; }
            [DataMember]
            public int thumb_id { get; set; }
            [DataMember]
            public int owner_id { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public int created { get; set; }
            [DataMember]
            public int updated { get; set; }
            [DataMember]
            public int size { get; set; }
            [DataMember]
            public int privacy { get; set; }
            [DataMember]
            public int comment_privacy { get; set; }
        }
    }
}
