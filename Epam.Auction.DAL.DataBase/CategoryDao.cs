using Epam.Auction.DAL.Contracts;
using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.Auction.DAL.DataBase
{
    public class CategoryDao : ICategoryDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public bool Create(Category category)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[Categories] ([Id],[Name]) VALUES(@Id,@Name)";
                command.Parameters.AddWithValue("@Id", category.Id);
                command.Parameters.AddWithValue("@Name", category.Name);
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

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Id], [Name] FROM [dbo].[Categories] ORDER BY [Name] ASC";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Category()
                    {
                        Id = (Guid)reader["Id"],
                        Name = (string)reader["Name"],
                    };
                }
            }
        }

        public bool Update(Category category)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Categories SET [Name]=@Name WHERE [Id]=@Id";
                command.Parameters.AddWithValue("@Id", category.Id);
                command.Parameters.AddWithValue("@Name", category.Name);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}
