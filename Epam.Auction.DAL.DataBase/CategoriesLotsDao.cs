using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Epam.Auction.DAL.Contracts;
using Epam.Auction.Entities;

namespace Epam.Auction.DAL.DataBase
{
    public class CategoriesLotsDao : ICategoriesLotsDao
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public bool Create(Guid categoryId, Guid lotId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[CategoriesLots] ([Id_Categories],[Id_Lots]) VALUES(@Id_Category,@Id_Lot)";
                command.Parameters.AddWithValue("@Id_Category", categoryId);
                command.Parameters.AddWithValue("@Id_Lot", lotId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Delete(Guid lotId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [dbo].[CategoriesLots] WHERE [Id_Lots]=@lotId";
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

        public IEnumerable<Lot> GetLotsByCategory(Guid categoryId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT [Id],[Name],[Desc],[Image],[UserId],[ExpireDate] 
                                        FROM[dbo].[Lots]
                                        RIGHT JOIN [dbo].[CategoriesLots]
                                        ON[dbo].[Lots].[Id] = [dbo].[CategoriesLots].[Id_Lots]
                                        WHERE [dbo].[CategoriesLots].[Id_Categories]=@Id_Category";
                command.Parameters.AddWithValue("@Id_Category", categoryId);
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
                    throw new ArgumentException();
                }
            }
        }
    }
}
