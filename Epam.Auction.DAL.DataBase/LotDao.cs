using Epam.Auction.DAL.Contracts;
using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.Auction.DAL.DataBase
{
    public class LotDao : ILotDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public bool Create(Lot lot)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[Lots] ([Id],[Name],[Desc],[Image],[UserId],[ExpireDate]) VALUES(@Id,@Name,@Desc,@Image,@UserId,@ExpireDate)";
                command.Parameters.AddWithValue("@Id", lot.Id);
                command.Parameters.AddWithValue("@Name", lot.Name);
                command.Parameters.AddWithValue("@Desc", lot.Desc);
                command.Parameters.AddWithValue("@Image", lot.Image);
                command.Parameters.AddWithValue("@UserId", lot.UserId);
                command.Parameters.AddWithValue("@ExpireDate", lot.ExpireDate);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(Lot lot)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Lots SET [Name]=@Name,[Desc]=@Desc,[Image]=@Image,[UserId]=@UserId,[ExpireDate]=@ExpireDate WHERE [Id]=@Id";
                command.Parameters.AddWithValue("@Id", lot.Id);
                command.Parameters.AddWithValue("@Name", lot.Name);
                command.Parameters.AddWithValue("@Desc", lot.Desc);
                command.Parameters.AddWithValue("@Image", lot.Image);
                command.Parameters.AddWithValue("@UserId", lot.UserId);
                command.Parameters.AddWithValue("@ExpireDate", lot.ExpireDate);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public IEnumerable<Lot> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Id], [Name], [Desc], [Image], [UserId], [ExpireDate] FROM [dbo].[Lots]";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new Lot()
                        {
                            Id = (Guid)reader["Id"],
                            Name = (string)reader["Name"],
                            Desc = (string)reader["Desc"],
                            Image = (byte[])reader["Image"],
                            UserId = (Guid)reader["UserId"],
                            ExpireDate = (DateTime)reader["ExpireDate"]
                        };
                    }
                }
                else
                {
                    throw new InvalidOperationException("No records were returned");
                }
            }
        }

        public Lot Get(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Id], [Name], [Desc], [Image], [UserId], [ExpireDate] FROM [dbo].[Lots] WHERE [Id]=@Id";
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Lot()
                    {
                        Id = (Guid)reader["Id"],
                        Name = (string)reader["Name"],
                        Desc = (string)reader["Desc"],
                        Image = (byte[])reader["Image"],
                        UserId = (Guid)reader["UserId"],
                        ExpireDate = (DateTime)reader["ExpireDate"]
                    };
                }

                throw new ArgumentException();
            }
        }

        public bool Delete (Guid lotId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [dbo].[Lots] WHERE [Id]=@lotId";
                command.Parameters.AddWithValue("@lotId", lotId);
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
