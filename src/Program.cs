using System.Configuration;

namespace HighCard
{
    class Program
    {
        static void Main()
        {
            Game game = new();
            int games = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfGames") ?? "52");
            game.Play(games);
        }
    }
}
