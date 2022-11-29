using Lab2.Accounts;
using Lab2.Games;

namespace Lab2;

internal static class Program
{
    public static void Main()
    {
        var player1 = new ThreeWinsInARowAccount("Anna");
        var player2 = new PremiumAccount("Kate");
        var player3 = new GameAccount("Max");

        var game1 = new StandardGame(player1, player3, 5);
        var game2 = new GameForOne(player1, player2, 6);
        var game3 = new TrainingGame(player3, player1, 0);
        var game4 = new GameForOne(player2, player3, 8);
        var game5 = new StandardGame(player1, player3, 7);
        var game6 = new TrainingGame(player3, player2, 0);

        game1.Play();
        game2.Play();
        game3.Play();
        game4.Play();
        game5.Play();
        game6.Play();

        Console.WriteLine(player1.GetStats());
        Console.WriteLine(player2.GetStats());
        Console.WriteLine(player3.GetStats());
    }
}