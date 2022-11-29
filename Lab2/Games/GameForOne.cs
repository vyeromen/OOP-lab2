using Lab2.Accounts;

namespace Lab2.Games;

public class GameForOne : Game
{
    public GameForOne(GameAccount player, GameAccount opponent, int rating)
        : base(player, opponent, rating)
    {
        Type = "For One";
    }

    public override void Play()
    {
        Random rnd = new();
        var ratingPlayer = rnd.Next(0, 2);
        var resultRandom = WinOrLose.Next(0, 2);

        if (ratingPlayer == 0)
        {
            if (resultRandom == 0)
            {
                Player.WinGame(this);
                Rating = 0;
                Opponent.LoseGame(this);
            }
            else
            {
                Player.LoseGame(this);
                Rating = 0;
                Opponent.WinGame(this);
            }
        }
        else
        {
            if (resultRandom == 0)
            {
                Opponent.WinGame(this);
                Rating = 0;
                Player.LoseGame(this);
            }
            else
            {
                Opponent.LoseGame(this);
                Rating = 0;
                Player.WinGame(this);
            }
        }
    }
}