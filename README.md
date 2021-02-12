# testing-entity-framework

This repo is a small sample trying out an technique that I have put together for testing Entity Framework migrations.

This project requires a local Postgres install. (Docker... Someday...)

Run the `create-database.sh` script to create the database. The connection strings are hard coded, and so the tests should 'just work' after the database has been set up. 

This repo is the sample code for [this](https://medium.com/@andy.watt83/testing-entity-framework-migrations-9bc5dc25190b) Medium story on testing Entity Framework migrations. 