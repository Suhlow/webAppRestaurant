using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using App.data.Db;
using Microsoft.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace App.data.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DbTest
    {

        [SetUp]
        public void Setup()
        {
            using (SqlConnection connection = new SqlConnection(
                @"server=delicemachine\mssqlserver01;database=netDb;trusted_connection=true;"))
            {
                string sql = @"if (exists(Select 1 from sys.tables where name = 'Notes')) DROP Table Notes 
                               if (exists(Select 1 from sys.tables where name = 'Restaurants')) DROP Table Restaurants 
                               if (exists(Select 1 from sys.tables where name = 'Adresses')) DROP Table Adresses";

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text; connection.Open();
                        command.ExecuteNonQuery(); connection.Close();
                    }
                }
                catch (System.Exception e) { }
            }
        }

        [Test]
        public void InitDbConnection()
        {
                var dbContext = new RestaurantContext();
                dbContext.Database.EnsureCreated();
                dbContext.Notes.ToList();
                dbContext.Adresses.ToList();
                dbContext.Restaurants.ToList();
        }
    }
}
