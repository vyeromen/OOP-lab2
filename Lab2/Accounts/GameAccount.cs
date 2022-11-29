using Lab2.Games;

namespace Lab2.Accounts;

public class GameAccount
{
    public string UserName { get; }
    protected readonly List<GameRecord> Records;

    private int CurrentRating
    {
        get
        {
            var rating = 1;
            foreach (var game in Records)
            {
                if (game.AccountRating < 0 && rating <= -game.AccountRating)
                    rating = 1;
                else rating += game.AccountRating;
            }

            return rating;
        }
    }

    public GameAccount(string name)
    {
        UserName = name;
        Records = new List<GameRecord>();
    }

    public virtual void WinGame(Game game)
    {
        var opponent = UserName == game.Player.UserName ? game.Opponent.UserName : game.Player.UserName;
        Records.Add(new GameRecord
        {
            Winner = UserName, Loser = opponent, Rating = game.Rating, Id = game.Id, AccountRating = game.Rating,
            Type = game.Type
        });
    }

    public virtual void LoseGame(Game game)
    {
        var opponent = UserName == game.Player.UserName ? game.Opponent.UserName : game.Player.UserName;
        Records.Add(new GameRecord
        {
            Winner = opponent, Loser = UserName, Rating = game.Rating, Id = game.Id, AccountRating = -game.Rating,
            Type = game.Type
        });
    }

    public string GetStats()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine();
        report.AppendLine($"\t\t\t\t\t  Stats for {UserName}");
        report.AppendLine(
            "___________________________________________________________________________________________________");
        report.AppendLine(
            "       ID         Game type      Winner      Loser      Rating     Changes in the player's rating");
        report.AppendLine(
            "---------------------------------------------------------------------------------------------------");

        foreach (var game in Records)
        {
            report.AppendLine(
                $"{game.Id,13}     {game.Type,-14} {game.Winner,-10}  {game.Loser,-11}  {game.Rating}  {game.AccountRating,20}");
            report.AppendLine(
                "---------------------------------------------------------------------------------------------------");
        }

        report.AppendLine($"Total Games Played: {Records.Count}");
        report.AppendLine($"Final Rating: {CurrentRating}");
        return report.ToString();
    }
}