using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Auction.Entities;

namespace Epam.Auction.DAL.DataBase
{
    public class LotsUsersDao : ILotsUsersDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;


        public bool Create(Guid lotId, Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[LotsUsers] ([Id_Lot],[Id_User]) VALUES(@Id_Lot,@Id_User)";
                command.Parameters.AddWithValue("@Id_Lot", lotId);
                command.Parameters.AddWithValue("@Id_User", userId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Delete(Guid lotID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [dbo].[LotsUsers]  WHERE [Id_Lot]=@lotId";
                command.Parameters.AddWithValue("@lotId", lotID);
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

        ////все лоты, на которые юзер сделал ставку последним
        public IEnumerable<Lot> GetBoughtLots(Guid idUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT [Id],[Name],[Desc],[Image],[UserId],[ExpireDate]
                                        FROM [dbo].[Lots]
                                        INNER JOIN [dbo].[LotsUsers]
                                        ON [dbo].[Lots].[Id] = [dbo].[LotsUsers].[Id_Lot]
                                        WHERE [dbo].[LotsUsers].[Id_User] = @UserId
                                        AND [dbo].[Lots].[UserId] != @UserId";
                command.Parameters.AddWithValue("@UserId", idUser);
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

        ////все лоты, размещенные юзером, со ставкой больше начальной
        public IEnumerable<Lot> GetSoldLots(Guid idUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT [Id],[Name],[Desc],[Image],[UserId],[ExpireDate]
                                        FROM [dbo].[Lots]
                                        INNER JOIN [dbo].[LotsUsers]
                                        ON [dbo].[Lots].[Id] = [dbo].[LotsUsers].[Id_Lot]
                                        WHERE [dbo].[LotsUsers].[Id_User] != @UserId
                                        AND [dbo].[Lots].[UserId] = @UserId";
                command.Parameters.AddWithValue("@UserId", idUser);
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

        public bool Update(Guid lotId, Guid newUserId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [dbo].[LotsUsers] SET [Id_User]=@Id_User WHERE [Id_Lot]=@Id_Lot";
                command.Parameters.AddWithValue("@Id_Lot", lotId);
                command.Parameters.AddWithValue("@Id_User", newUserId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}
