using System;
using Common;

namespace SelfHost.Model
{
    public interface IGameContext
    {
        void Connect(string id, AuthType authType);
        void Disconnect();
        void PushIdForSearch(string id, Mode mode);
        void RemoveIdForSearch(string id);
        void Pick(Gesture gesture, Guid lobiId);
        void ExitLobi(Guid lobiId, string oponentId);
        void StartGame(Guid lobiId, string id);
        //void IgnoreOponent(string oponentId);
        void PlayAgain(Guid lobiId);
    }
}
