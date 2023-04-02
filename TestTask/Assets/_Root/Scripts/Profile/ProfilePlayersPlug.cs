using Tool;

namespace Profile
{
    public class ProfilePlayersPlug
    {
        public readonly SubscriptionProperty<GameStatePlug> CurrentState;

        public ProfilePlayersPlug(GameStatePlug initialState)
        {
            CurrentState = new SubscriptionProperty<GameStatePlug>(initialState);
        }
    }
}
