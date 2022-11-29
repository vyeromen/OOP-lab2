namespace Lab2.Games;

public class GameRecord
{
    public int Id { get; init; }
    public string? Winner { get; init; }
    public string? Loser { get; init; }
    public int Rating { get; init; }
    public int AccountRating { get; init; }
    public string? Type { get; init; }
}