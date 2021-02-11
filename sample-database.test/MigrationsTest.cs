using Dapper;
using FluentAssertions;
using Npgsql;
using System;
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

            // Check that the blog table has been populated correctly
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var actual = connection.Query<(string, string)>(@"select ""Name"", ""Tagline"" from ""Blogs""");
                var expected = new[] {
                    ("My Life", "Making my life look more exciting than it is"),
                    ("Coding Things", "Rockstar Coders") };
                actual.Should().BeEquivalentTo(expected);
            }

            // Spot check the posts table
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var actual = connection.Query<DateTime>(@"select ""Date"" from ""Posts""");
                var expected = new[] {
                    new DateTime(2011, 3, 14),
                    new DateTime(2012, 3, 14),
                    new DateTime(2013, 3, 14),
                    new DateTime(2014, 3, 14)
                };
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact, MigrationTest(1)]
        public async void TestAuthorTablelMigration()
        {
            // Before the migration is run, the 'AuthorName' column should be present
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var actual = connection.Query<string>(@"select column_name from information_schema.columns where table_name = 'Posts'");
                actual.Should().Contain("AuthorName");
            }

            // Set the migration
            await this.DatabaseFixture.SetMigration("author-table");

            // Check that the new Authors table contains the correct data
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var actual = connection.Query<string>(@"select ""DisplayName"" from ""Authors""");
                var expected = new[] { "Andy Watt", "Richard Whiteley", "Carol Vorderman" };
                actual.Should().BeEquivalentTo(expected);
            }

            // Before the migration is run, the 'AuthorName' column should be changed to 'AuthorId'
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var actual = connection.Query<string>(@"select column_name from information_schema.columns where table_name = 'Posts'");
                actual.Should().Contain("AuthorId");
                actual.Should().NotContain("AuthorName");
            }
        }
    }
}
