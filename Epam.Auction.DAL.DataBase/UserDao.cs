using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Auction.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.Auction.DAL.DataBase
{
    public class UserDao : IUserDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public bool Create(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[Users] ([Id],[Name],[Hash],[Salt]) VALUES(@Id,@Name,@Hash,@Salt)";
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Hash", user.Hash);
                command.Parameters.AddWithValue("@Salt", user.Salt);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public User GetUser(string userName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Id],[Name],[Hash],[Salt] FROM [dbo].[Users] WHERE [Name]=@Name";
                command.Parameters.AddWithValue("@Name", userName);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User()
                    {
                        Id = (Guid)reader["Id"],
                        Name = (string)reader["Name"],
                        Hash = (byte[])reader["Hash"],
                        Salt = (Guid)reader["Salt"],
                    };
                }

                throw new ArgumentException("Incorrect user's name");
            }
        }

        public bool IsUserExist(string userName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Name] FROM [dbo].[Users] WHERE [Name]=@Name";
                command.Parameters.AddWithValue("@Name", userName);
                connection.Open();
                var reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Id],[Name],[Hash],[Salt] FROM [dbo].[Users]";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new User()
                        {
                            Id = (Guid)reader["Id"],
                            Name = (string)reader["Name"],
                            Hash = (byte[])reader["Hash"],
                            Salt = (Guid)reader["Salt"],
                        };
                    }
                }
                else
                {
                    throw new InvalidOperationException("No records were returned");
                }
            }
        }
    }   
}
