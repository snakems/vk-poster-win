using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_poster
{
    class VkApiException : System.ApplicationException
    {
        public VkApiException() { }
        public VkApiException(string message) { }
        public VkApiException(string message, System.Exception inner) { }
    }
}
