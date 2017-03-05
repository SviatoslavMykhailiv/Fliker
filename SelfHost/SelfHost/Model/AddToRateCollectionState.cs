namespace SelfHost.Model
{
    public class AddToRateCollectionState : IAddState
    {
        private readonly AddState _addState;

        public AddToRateCollectionState(AddState addState)
        {
            _addState = addState;
        }

        public void Add(User user)
        {
            var found = _addState.UserCollection.Find(c => c.Id == user.Id);

            if (found == null)
            {
                _addState.UserCollection.RateUsers.Add(user, "RateUsers");
            }
            else
            {
                switch (found.Mode)
                {
                    case Mode.Fun:
                        _addState.UserCollection.FunUsers.Remove(user, "FunUsers");
                        _addState.UserCollection.RateUsers.Add(user, "RateUsers");
                        break;
                    case Mode.None:
                        _addState.UserCollection.NoneUsers.Remove(user, "NoneUsers");
                        _addState.UserCollection.RateUsers.Add(user, "RateUsers");
                        break;
                }
            }
        }
    }
}