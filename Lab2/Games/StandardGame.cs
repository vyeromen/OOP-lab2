using Lab2.Accounts;

namespace Lab2.Games;

public class StandardGame : Game
{
    public StandardGame(GameAccount player, GameAccount opponent, int rating)
        : base(player, opponent, rating)
    {
        Type = "Standard";
    }

    public override void Play()
    {
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