using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class GameDataService
    {
        // Ophalen connectionstring uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDBconnection class en instatiëren can een SqlConnection.
        // Zodat de connectie met database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Game> GetGameSettings()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string.
            string sql = "SELECT * FROM Game g " +
                "JOIN Setting s ON g.SettingId = s.Id";
            var games = db.Query<Game, Setting, Game>(sql, (game, setting) =>
                {
                    game.Setting = setting;
                    return game;
                },
            splitOn: "Id");

            //stap 3 Dapper
            // Uitschrijven SQL statement op db instance
            // Type casten van het generieke return type naar een collectie can players
            return new ObservableCollection<Game>((List<Game>)games);
        }

        public void UpdateGameSettings(Game game)
        {
            // SQL query UPDATE
            string sql = "Update Game set AantalRondes = @aantalRondes, AantalStartTroepen = @aantalStartTroepen, AantalTroepenPerBeurt = @aantalTroepenPerBeurt where id = @id";

            //uitvoeren query
            //db.Execute(sql, new { game.AantalRondes, game.AantalStartTroepen, game.AantalTroepenPerBeurt, game.Id});
        }


    }
}
