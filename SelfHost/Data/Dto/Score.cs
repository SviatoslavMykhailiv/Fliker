using System;
using Common;

namespace Data.Dto
{
    public class Score
    {
        public Guid Id { get; }
        public string UserId { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public AuthType SocialNetwork { get; set; }
    }
}
