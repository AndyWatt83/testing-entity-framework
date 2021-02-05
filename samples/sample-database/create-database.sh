set -ex

psql --dbname=postgres --username=postgres -c "CREATE DATABASE blogging_demo"

psql --dbname=postgres --username=postgres -c "
CREATE USER local_dev WITH PASSWORD 'local_dev';
GRANT ALL PRIVILEGES ON DATABASE blogging_demo to local_dev;