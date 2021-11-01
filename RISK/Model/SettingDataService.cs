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
    class SettingDataService
    {
        // Ophalen connectionstring uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDBconnection class en instatiëren can een SqlConnection.
        // Zodat de connectie met database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Setting> GetSettings()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string.
            string sql = "SELECT * FROM Setting";

            //stap 3 Dapper
            // Uitschrijven SQL statement op db instance
            // Type casten van het generieke return type naar een collectie can players
            return new ObservableCollection<Setting>((List<Setting>)db.Query<Setting>(sql));
        }
        public void UpdateSettings(Setting setting)
        {
            // SQL query UPDATE
            string sql = "Update Setting set AantalRondes = @aantalRondes, AantalStartTroepen = @aantalStartTroepen, AantalTroepenPerBeurt = @aantalTroepenPerBeurt where id = @id";

            //uitvoeren query
            db.Execute(sql, new { setting.AantalRondes, setting.AantalStartTroepen, setting.AantalTroepenPerBeurt, setting.Id});
        }
    }
}
