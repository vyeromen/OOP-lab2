using Lab2.Games;

namespace Lab2.Accounts;

public class ThreeWinsInARowAccount : GameAccount
{
    private int _winsCount;

    public ThreeWinsInARowAccount(string userName) : base(userName)
    {
        _winsCount = 0;
    }

    public override void WinGame(Game game)
    {
        _winsCount++;
        int rating;
        if (_winsCount == 3)
        {
            rating = game.Rating + 5;
            _winsCount = 0;
        }
        else rating = game.Rating;

        var opponent = UserName == game.Player.UserName ? game.Opponent.UserName : game.Player.UserName;
        Records.Add(new GameRecord
        {
            Winner = UserName, Loser = opponent, Rating = game.Rating, Id = game.Id, AccountRating = rating,
            Type = game.Type
        });
    }

    public override void LoseGame(Game game)
    {
        _winsCount = 0;
        base.LoseGame(game);
    }
}