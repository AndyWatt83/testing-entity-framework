
using Dapper;
using FluentAssertions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace SampleDatabase.Test
{
    [TestCaseOrderer("TestingEntityFramework.MigrationTestOrderer", "TestingEntityFramework")]
    public class MigrationsTest : IClassFixture<MigratingDatabaseFixture>
    {
        private MigratingDatabaseFixture _databaseFixture;
        private string _connectionString = "Host=localhost;Port=5432;Username=local_dev;Password=local_dev;Database=blogging_demo";

        public MigrationsTest(MigratingDatabaseFixture databaseFixture)
        {
            this._databaseFixture = databaseFixture;
        }

        public MigratingDatabaseFixture DatabaseFixture => _databaseFixture;

        [Fact, MigrationTest(0)]
        public async void TestInitialMigration()
        {
            await this.DatabaseFixture.SetMigration("Initial");
            this.DatabaseFixture.RunScript(@".\Scripts\initial-data.sql");

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var actual = connection.Query<(string, string)>(@"select ""Name"", ""Tagline"" from ""Blogs""");
                var expected = new[] { ("My Life", "Making my life look more exciting than it is"), ("Mad Coding Skillz", "Rockstar Coders") };
                actual.Should().BeEquivalentTo(expected);
            }

        }

        [Fact, MigrationTest(1)]
        public async void TestDateFieldMigration()
        {
            await this.DatabaseFixture.SetMigration("datefield");
            this.DatabaseFixture.RunScript(@".\Scripts\initial-data.sql");
            // Test veracity of the data
            await this.DatabaseFixture.SetMigration("Initial");
            // Test veracity of the data
            await this.DatabaseFixture.SetMigration("datefield");
        }

        [Fact, MigrationTest(2)]
        public async void TestAuthorTablelMigration()
        {
            await this.DatabaseFixture.SetMigration("authortable");
            this.DatabaseFixture.RunScript(@".\Scripts\initial-data.sql");
        }
    }

    //public static class DapperExtensions
    //{
    //    public static IEnumerable<T> Query<T>(this IDbConnection connection, Func<T> typeBuilder, string sql)
    //    {
    //        return connection.Query<T>(sql);
    //    }
    //}

    public class InitialPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
