using System.Collections.Generic;
using System.Data;  // For IDBConnection
using System.Data.SqlClient;  // For SqlConnection
using System.Linq;
using Dapper;  // For Query, Execute

namespace W13_AzureSQLDataAccess
{
    public static class DataAccess
    {
        // Find you connection string in:
        // a) azure portal > clickycratesdb resource > Connection Strings > ADO.NET
        // b) Visual Studio SQL Server Object Explorer > xxx.database.windows.net >
        //     Right click > Properties 
        static string _connectionString;

        public static void InitConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }


        public static List<User> GetUsers()
        {
            using (IDbConnection cnn = new SqlConnection(_connectionString))
            {
                string sql = $"SELECT * FROM [dbo].[User]";
                // Remember to use the square brackets and dbo first for MSSQL
                var users = cnn.Query<User>(sql).ToList();
                return users;
            }
        }

        public static int RegisterUser(User newUser)
        {
            using (IDbConnection cnn = new SqlConnection(_connectionString))
            {
                string sql = $"INSERT INTO [dbo].[User](FirstName, LastName, Nickname, Email, Password) " +
                    $"VALUES ({newUser.FirstName},{newUser.LastName},{newUser.Nickname},{newUser.Email},{newUser.Password})";
                int rowsReturned = cnn.Execute(sql);
                return rowsReturned;
            }
        }
    }
}
