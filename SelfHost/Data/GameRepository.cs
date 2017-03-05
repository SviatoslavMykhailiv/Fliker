using System.Linq;
using Common;
using Data.Dto;

namespace Data
{
    public class GameRepository
    {
        private readonly ApplicationContext _ctx;

        public GameRepository()
        {
            _ctx = new ApplicationContext();
        }

        public void AddScore(string playerId, WinLose winLose, AuthType authType)
        {
            var userScores = _ctx.Scores.FirstOrDefault(c => c.UserId == playerId);

            if (userScores == null)
            {
                _ctx.Scores.Add(new Score
                {
                    SocialNetwork = authType,
                    Wins = winLose == WinLose.Win ? 1 : 0,
                    Loses = winLose == WinLose.Lose ? 1 : 0,
                    UserId = playerId
                });
            }
            else
            {
                switch (authType)
                {
                        
                }
            }
        }
    }
}
