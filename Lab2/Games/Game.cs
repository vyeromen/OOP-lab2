using Lab2.Accounts;

namespace Lab2.Games;

public abstract class Game
{
    public GameAccount Player { get; }
    public GameAccount Opponent { get; }
    public int Rating { get; protected set; }
    protected readonly Random WinOrLose = new();
    private static int _startId = 1234567890;
    public readonly int Id;
    public string Type { get; protected init; }

    protected Game(GameAccount player, GameAccount opponent, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentOutOfRangeException("Rating must be positive");
        }

        if (player.UserName.Equals(opponent.UserName)) throw new Exception("Names must be different");

        Player = player;
        Opponent = opponent;
        Rating = rating;
        Type = "Game";
        Id = _startId;
        _startId++;
    }

    public abstract void Play();
}