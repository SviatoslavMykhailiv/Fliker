using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfHost.Model
{
    public class UserCollection
    {
        private readonly object _sync = new object();

        public readonly List<User> RateUsers;
        public readonly List<User> FunUsers;
        public readonly List<User> NoneUsers;
        private readonly AddState _addState;

        private UserCollection()
        {
            RateUsers = new List<User>();
            FunUsers = new List<User>();
            NoneUsers = new List<User>();
            _addState = new AddState(this);
        }

        public void Add(User user, Mode mode = Mode.None)
        {
            _addState.Add(user, mode);
        }

        public void Remove(User user)
        {
            var result = Find(c => c.Id == user.Id);
            Remove(result.User, result.Mode);
        }

        public UserSearchResult Find(Predicate<User> predicate)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            User foundUser = NoneUsers.Find(predicate);

            if(foundUser != null)
                return new UserSearchResult(foundUser, Mode.None);

            foundUser = FunUsers.Find(predicate);

            if(foundUser != null)
                return new UserSearchResult(foundUser, Mode.Fun);

            foundUser = RateUsers.Find(predicate);

            if(foundUser != null)
                return new UserSearchResult(foundUser, Mode.Rate);

            return null;
        }

        private void Remove(User user, Mode mode)
        {
            switch (mode)
            {
                case Mode.None:
                    lock (_sync)
                        NoneUsers.Remove(user, nameof(NoneUsers));
                    break;
                case Mode.Fun:
                    lock (_sync)
                        FunUsers.Remove(user, nameof(FunUsers));
                    break;
                case Mode.Rate:
                    lock (_sync)
                        RateUsers.Remove(user, nameof(RateUsers));
                    break;
            }
        }

        public User FindNextFor(User user, Mode mode)
        {
            Func<User, bool> predicate = c => c.Id != user.Id
                                              && c.CanBeSearched
                                              && (!c.OponentsToIgnore.Exists(p => p.Id == user.Id || mode == Mode.Fun))
                                              && (!c.OponentsAlreadyPlayedWith.Exists(p => p.Id == user.Id || mode == Mode.Fun));

            switch (mode)
            {
                case Mode.Fun:
                    return FunUsers.FirstOrDefault(predicate);
                case Mode.Rate:
                    return RateUsers.FirstOrDefault(predicate);
            }

            return null;
        }

        public static UserCollection Current => _current ?? (_current = new UserCollection());

        private static UserCollection _current;
    }
}
