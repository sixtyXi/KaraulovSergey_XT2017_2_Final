using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.DataBase
{
    public class UsersRolesDao : IUsersRolesDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public string[] GetAllRoles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Role] FROM [dbo].[Roles]";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<string> roles = new List<string>();
                    while (reader.Read())
                    {
                        roles.Add(reader["Role"].ToString());
                    }
                    return roles.ToArray();
                }
                else
                {
                    throw new InvalidOperationException("No records were returned");
                }
            }
        }

        public string[] GetRolesForUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT Role      
                                          FROM Roles
                                          LEFT JOIN UsersRoles
                                          ON Roles.Id = UsersRoles.Id_Role
                                          LEFT JOIN Users
                                          ON UsersRoles.Id_User = Users.Id
                                          WHERE Users.Name = @UserName";
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<string> roles = new List<string>();
                    while (reader.Read())
                    {
                        roles.Add(reader["Role"].ToString());
                    }
                    return roles.ToArray();
                }
                else
                {
                    throw new InvalidOperationException("No records were returned");
                }
            }
        }

        public bool Create(string userName, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO UsersRoles ([Id_User],[Id_Role])
                                        VALUES(
                                        (SELECT Users.Id FROM Users WHERE Users.Name = @UserName),
                                        (SELECT Roles.Id FROM Roles WHERE Roles.Role = @Role))";
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Role", roleName);
                connection.Open();
                try
                {
                    return command.ExecuteNonQuery() == 1;
                }
                catch (Exception)
                {
                    throw new Exception("Row isn't added");
                }
            }
        }

        public bool Delete(string userName, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"DELETE FROM UsersRoles 
                                        WHERE [Id_User] IN
                                        (SELECT Users.Id FROM Users WHERE [Name]=@Name)
                                        AND [Id_Role] IN
                                        (SELECT Roles.Id FROM Roles WHERE [Role]=@Role)";
                command.Parameters.AddWithValue("@Name", userName);
                command.Parameters.AddWithValue("@Role", roleName);
                connection.Open();
                try
                {
                    return command.ExecuteNonQuery() == 1;
                }
                catch (Exception)
                {
                    throw new Exception("Row isn't deleted");
                }
            }
        }
    }
}
