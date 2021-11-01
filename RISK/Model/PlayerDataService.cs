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
    class PlayerDataService
    {
        // Ophalen connectionstring uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDBconnection class en instatiëren can een SqlConnection.
        // Zodat de connectie met database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

//SELECT
        public List<Player> GetPlayers()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string.
            string sql = "SELECT * FROM Player ORDER BY Name";

            //stap 3 Dapper
            // Uitschrijven SQL statement op db instance
            // Type casten van het generieke return type naar een collectie can players
            
            return (List<Player>)db.Query<Player>(sql);
        }

        public ObservableCollection<Player> GetPlayersJoined()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string.
            string sql = "SELECT * FROM Player p " +
                "JOIN Country c ON p.Id = c.PlayerId";
            var players = db.Query<Player, Country, Player>(sql, (player, countries) =>
            {
                player.Countries = (ICollection<Country>)countries;
                return player;
            },
            splitOn: "Id");

            //stap 3 Dapper
            // Uitschrijven SQL statement op db instance
            // Type casten van het generieke return type naar een collectie can players

            return new ObservableCollection<Player>((List<Player>)players);
        }

        //UPDATE
        public void UpdatePlayer(Player player)
        {
            // SQL query UPDATE
            string sql = "Update Player set name = @name, color = @color where id = @id";

            //uitvoeren query
            db.Execute(sql, new { player.Name, player.Color, player.Id });
        }
        public void UpdateAantalStartTroepen(Player player)
        {
            // SQL query UPDATE
            string sql = "Update Player set AantalTroepen = @aantalTroepen where id = @id";

            //uitvoeren query
            db.Execute(sql, new { player.AantalTroepen, player.Id });
        }

//INSERT
        public void InsertPlayer(Player player)
        {
            // SQL query INSERT
            string sql = "INSERT into Player (name, color, gameId) values (@name, @color, @gameId)";

            //uitvoeren query
            db.Execute(sql, new { player.Name, player.Color, player.GameId });
        }

//DELETE
        public void DeletePlayer(Player player)
        {
            // SQL query DELETE
            string sql = "DELETE Player where id = @id";

            //uitvoeren query
            db.Execute(sql, new { player.Id });
        }
    }
}
