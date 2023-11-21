using Dapper;
using DapperTrial.Models;
using MySqlConnector;

namespace DapperTrial.DataAccess
{
    public class CityQuery
    {
        public CityQuery() { }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();

            string sql = "SELECT * FROM City WHERE Population BETWEEN 100000 AND 300000";

            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=Samoo_1992;user=root";

            using (var connection  = new MySqlConnection(connectionString))
            {
                cities = connection.Query<City>(sql).ToList();
            }

            return cities;

        }

        public List<City> LimitCities()
        {
            List<City> limitedCities = new List<City>();
            string sql = "SELECT * FROM City LIMIT 15";
            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=Samoo_1992;user=root";
            using (var connection = new MySqlConnection(connectionString))
            {
                limitedCities = connection.Query<City>(sql).ToList();
            }
            return limitedCities;
        }
        public List<City> CitiesByCountryCode()
        {
            List<City> codes = new List<City>();
            string sql = "SELECT name, countrycode From City";
            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=Samoo_1992;user=root";
            using (var connection = new MySqlConnection(connectionString))
            {
                codes = connection.Query<City>(sql).ToList();
            }
            return codes;
        }

        
        public List<City> GetCitiesInCountry()
        {
            List<City> countryCities = new List<City>();

            string sql = "SELECT * FROM City WHERE CountryCode = 'PSE'";

            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=Samoo_1992;user=root";

            using (var connection = new MySqlConnection(connectionString))
            {
                countryCities = connection.Query<City>(sql).ToList();
            }

            return countryCities;

        }

        public List<City> GetCitiesInContinent()
        {
            List<City> continentCities = new List<City>();

            string sql = "SELECT City.Name, Country.Continent, country.LifeExpectancy From country Join City On Country.Code = City.CountryCode Where Continent = 'Asia' And LifeExpectancy > 55;";

            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=Samoo_1992;user=root";

            using (var connection = new MySqlConnection(connectionString))
            {
                continentCities = connection.Query<City>(sql).ToList();
            }

            return continentCities;

        }
    }
}
