using Dapper;
using DapperTrial.Models;
using MySqlConnector;

namespace DapperTrial.DataAccess
{
    public class CountryQuery
    {
        public CountryQuery() { }

        public List<Country> GetEuropeanCountries()
        {
            List<Country> countries = new List<Country>();

            string sql = "SELECT Code, Name, Continent, LifeExpectancy FROM Country WHERE Country.Continent = 'Europe' ORDER BY LifeExpectancy DESC";

            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=Samoo_1992;user=root";

            using (var connection = new MySqlConnection(connectionString))
            {
                countries = connection.Query<Country>(sql).ToList();
            }

            return countries;

        }
    }
}
