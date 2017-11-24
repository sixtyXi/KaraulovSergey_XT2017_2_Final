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
    public class LotsCostsDao : ILotsCostsDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;


        public bool Create(Guid lotId, decimal cost)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[LotsCosts] ([Id_Lot],[Cost]) VALUES(@Id_Lot,@Cost)";
                command.Parameters.AddWithValue("@Id_Lot", lotId);
                command.Parameters.AddWithValue("@Cost", cost);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Delete(Guid lotId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [dbo].[LotsCosts]  WHERE [Id_Lot]=@lotId ";
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

        public decimal GetCost(Guid lotId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Cost] FROM [dbo].[LotsCosts] WHERE [Id_Lot]=@Id_Lot";
                command.Parameters.AddWithValue("@Id_Lot", lotId);
                connection.Open();
                try
                {
                    return (decimal)command.ExecuteScalar();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Update(Guid lotId, decimal newCost)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [dbo].[LotsCosts] SET [Cost]=@Cost WHERE [Id_Lot]=@Id_Lot";
                command.Parameters.AddWithValue("@Id_Lot", lotId);
                command.Parameters.AddWithValue("@Cost", newCost);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
        ////все ставки юзера
        public IDictionary<Guid, decimal> GetAllBets(Guid idUser)
        {
            var lotsCost = new Dictionary<Guid, decimal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT [dbo].[LotsCosts].[Id_Lot], [Cost]     
                                        FROM [dbo].[LotsCosts]
                                        INNER JOIN [dbo].[LotsUsers]
                                        ON [dbo].[LotsCosts].[Id_Lot] = [dbo].[LotsUsers].[Id_Lot]  
                                        WHERE [Id_User] = @UserId";
                command.Parameters.AddWithValue("@UserId", idUser);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lotsCost.Add((Guid)reader["Id_Lot"], (decimal)reader["Cost"]);
                    }

                    return lotsCost;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        ////цены лотов, размещенных юзером
        public IDictionary<Guid, decimal> GetPlacedLotsCost(Guid idUser)
        {
            var lotsCost = new Dictionary<Guid, decimal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT [Id], [Cost]     
                                        FROM [dbo].[LotsCosts]
                                        INNER JOIN [dbo].[Lots]
                                        ON [dbo].[LotsCosts].[Id_Lot] = [dbo].[Lots].[Id]  
                                        WHERE [UserId] = @UserId";
                command.Parameters.AddWithValue("@UserId", idUser);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lotsCost.Add((Guid)reader["Id"], (decimal)reader["Cost"]);
                    }

                    return lotsCost;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
