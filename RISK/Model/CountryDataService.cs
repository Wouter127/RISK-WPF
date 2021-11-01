using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class CountryDataService
    {
        // Ophalen connectionstring uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDBconnection class en instatiëren can een SqlConnection.
        // Zodat de connectie met database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);



        public List<Country> GetCountriesJoined()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string.
            string sql = "SELECT * FROM Country c INNER JOIN Player p ON c.PlayerId = p.Id";

            var countries = db.Query<Country, Player, Country>(sql, (country, player) =>
            {
                country.Player = player;
                return country;
            },
            splitOn: "Id");

            //stap 3 Dapper
            // Uitschrijven SQL statement op db instance
            // Type casten van het generieke return type naar een collectie van countries
            return (List<Country>)countries;
        }
        public List<Country> GetCountries()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string.
            string sql = "SELECT * FROM Country";

            //stap 3 Dapper
            // Uitschrijven SQL statement op db instance
            // Type casten van het generieke return type naar een collectie van countries
            return (List<Country>)db.Query<Country>(sql);
        }
        public void InsertCountry(Country country)
        {
            string sql = "INSERT INTO Country(GameId, CountryName, PositionLeft, PositionTop, NumberOfSoldiers, Continent) VALUES(@gameId, @countryName, @positionleft, @positiontop, @numberOfSoldiers, @continent)";
            //uitvoeren query
            db.Execute(sql, new { country.GameId, country.CountryName, country.PositionLeft, country.PositionTop, country.NumberOfSoldiers, country.Continent });
        }

        public void DeleteCountry(Country country)
        {
            // SQL query DELETE
            string sql = "DELETE Country where id = @id";

            //uitvoeren query
            db.Execute(sql, new { country.Id });
        }

        public void UpdateCountry(Country country)
        {
            // SQL query UPDATE
            string sql = "Update Country set playerId = @playerId where id = @id";

            //uitvoeren query
            db.Execute(sql, new { country.PlayerId, country.Id });
        }
    }
}
