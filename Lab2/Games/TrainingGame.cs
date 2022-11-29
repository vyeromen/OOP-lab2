using Lab2.Accounts;

namespace Lab2.Games;

public class TrainingGame : Game
{
    public TrainingGame(GameAccount player, GameAccount opponent, int rating)
        : base(player, opponent, rating)
    {
        Type = "Training";
    }

    public override void Play()
    {
        Rating = 0;
        var resultRandom = WinOrLose.Next(0, 2);
        if (resultRandom == 0)
        {
            Player.WinGame(this);
            Opponent.LoseGame(this);
        }
        else
        {
            Player.LoseGame(this);
            Opponent.WinGame(this);
        }
    }
}