using Lab2.Games;

namespace Lab2.Accounts;

public class PremiumAccount : GameAccount
{
    public PremiumAccount(string userName) : base(userName)
    {
    }

    public override void WinGame(Game game)
    {
        var rating = game.Rating * 2;
        var opponent = UserName == game.Player.UserName ? game.Opponent.UserName : game.Player.UserName;
        Records.Add(new GameRecord
        {
            Winner = UserName, Loser = opponent, Rating = game.Rating, Id = game.Id, AccountRating = rating,
            Type = game.Type
        });
    }

    public override void LoseGame(Game game)
    {
        var rating = game.Rating / 2;
        var opponent = UserName == game.Player.UserName ? game.Opponent.UserName : game.Player.UserName;
        Records.Add(new GameRecord
        {
            Winner = opponent, Loser = UserName, Rating = game.Rating, Id = game.Id, AccountRating = -rating,
            Type = game.Type
        });
    }
}