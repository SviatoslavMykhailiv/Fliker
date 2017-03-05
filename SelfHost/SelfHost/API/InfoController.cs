using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SelfHost.Model;

namespace SelfHost.API
{
    public class InfoController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> OnlineUsers()
        {
            return null;
        }
    }
}
