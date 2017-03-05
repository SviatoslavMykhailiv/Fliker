namespace SelfHost.Model
{
    public class UserSearchResult
    {
        public User User { get; }
        public Mode Mode { get; }

        public UserSearchResult(User user, Mode mode)
        {
            User = user;
            Mode = mode;
        }
    }
}
