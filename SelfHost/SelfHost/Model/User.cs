using System.Collections.Generic;
using Common;

namespace SelfHost.Model
{
    public class User
    {
        public string Id { get; set; }
        public string ConnectionId { get; set; }
        public bool CanBeSearched { get; set; }
        public List<User> OponentsAlreadyPlayedWith { get; set; } = new List<User>();
        public List<User> OponentsToIgnore { get; set; } = new List<User>();
        public AuthType SocialNetwork { get; set; }
    }
}
