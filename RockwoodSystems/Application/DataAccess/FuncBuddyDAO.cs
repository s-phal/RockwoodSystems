using Dapper;
using Microsoft.Data.Sqlite;
using RockwoodSystems.Application.Config;
using RockwoodSystems.Application.Models;
using System.Data;


namespace RockwoodSystems.Application.DataAccess
{
    public class FuncBuddyDAO
    {
        public string connectionString { get; } = DBConnection.GetConnectionString();

        public List<FuncBuddy> RetrieveAll()
        {

            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM func_buddy";

                return connection.Query<FuncBuddy>(sqlQuery).ToList();

            }
        }

        public void Create(FuncBuddy funcBuddy)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                string sqlQuery = "" +
                "INSERT INTO func_buddy " +
                "(title, content, language_id) " +
                "VALUES " +
                "(@Title, @Content, 1) ";

                connection.Execute(sqlQuery, new
                {
                    Title = funcBuddy.title,
                    Content = funcBuddy.content
                });
            }
        }

    }

}
