using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace vk_poster
{
    [DataContract]
    class VkApiResponsePhotosGetAlbums : VkApiResponse
    {
        [DataMember]
        public VkApiResponseResult response { get; set; }

        //aid — идентификатор альбома;
        //thumb_id — идентификатор фотографии, которая является обложкой;
        //owner_id — идентификатор владельца альбома;
        //title — название альбома;
        //description — описание альбома; (не приходит для системных альбомов)
        //created — дата создания альбома в формате unixtime; (не приходит для системных альбомов)
        //updated — дата последнего обновления альбома в формате unixtime; (не приходит для системных альбомов)
        //size — количество фотографий в альбоме;
        //privacy — настройки приватности для альбома; (не приходит для системных альбомов)
        //thumb_src — ссылка на изображение обложки альбома (если был указан параметр need_covers).

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
            public int updated{ get; set; }
            [DataMember]
            public int size { get; set; }
            [DataMember]
            public int privacy { get; set; }
            [DataMember]
            public string thumb_src { get; set; }
        }
    }
}
