namespace SelfHost.Model
{
    public class AddToNoneCollectionState : IAddState
    {
        private readonly AddState _addState;

        public AddToNoneCollectionState(AddState addState)
        {
            _addState = addState;
        }

        public void Add(User user)
        {
            var found = _addState.UserCollection.Find(c => c.Id == user.Id);

            if (found == null)
            {
                _addState.UserCollection.NoneUsers.Add(user, "NoneUsers");
            }
            else
            {
                switch (found.Mode)
                {
                    case Mode.Fun:
                        _addState.UserCollection.FunUsers.Remove(user, "FunUsers");
                        _addState.UserCollection.NoneUsers.Add(user, "NoneUsers");
                        break;
                    case Mode.Rate:
                        _addState.UserCollection.RateUsers.Remove(user, "RateUsers");
                        _addState.UserCollection.NoneUsers.Add(user, "NoneUsers");
                        break;
                }
            }
        }
    }
}