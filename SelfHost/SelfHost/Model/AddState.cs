namespace SelfHost.Model
{
    public class AddState
    {
        public AddToFunCollectionState AddToFunCollectionState { get; set; }
        public AddToRateCollectionState AddToRateCollectionState { get; set; }
        public AddToNoneCollectionState AddToNoneCollectionState { get; set; }
        public UserCollection UserCollection { get; }

        public AddState(UserCollection userCollection)
        {
            UserCollection = userCollection;
            AddToFunCollectionState = new AddToFunCollectionState(this);
            AddToRateCollectionState = new AddToRateCollectionState(this);
            AddToNoneCollectionState = new AddToNoneCollectionState(this);
        }

        public IAddState CurrentState { get; set; }

        public void Add(User user, Mode mode)
        {
            switch (mode)
            {
                case Mode.Fun:
                    CurrentState = AddToFunCollectionState;
                    break;
                case Mode.Rate:
                    CurrentState = AddToRateCollectionState;
                    break;
                case Mode.None:
                    CurrentState = AddToNoneCollectionState;
                    break;
            }

            CurrentState.Add(user);
        }
    }
}