using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_poster
{
    class VkAuthException : System.ApplicationException
    {
        public VkAuthException() { }
        public VkAuthException(string message) { }
        public VkAuthException(string message, System.Exception inner) { }
    }
}
