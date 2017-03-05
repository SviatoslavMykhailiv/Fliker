namespace SelfHost.Model
{
    public class AddToFunCollectionState : IAddState
    {
        private readonly AddState _addState;

        public AddToFunCollectionState(AddState addState)
        {
            _addState = addState;
        }

        public void Add(User user)
        {
            var found = _addState.UserCollection.Find(c => c.Id == user.Id);

            if (found == null)
            {
                _addState.UserCollection.FunUsers.Add(user, "FunUsers");
            }
            else
            {
                switch (found.Mode)
                {
                    case Mode.Rate:
                        _addState.UserCollection.RateUsers.Remove(user, "RateUsers");
                        _addState.UserCollection.FunUsers.Add(user, "FunUsers");
                        break;
                    case Mode.None:
                        _addState.UserCollection.NoneUsers.Remove(user, "NoneUsers");
                        _addState.UserCollection.FunUsers.Add(user, "FunUsers");
                        break;
                }
            }
        }
    }
}