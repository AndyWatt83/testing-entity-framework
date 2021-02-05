PRAGMA foreign_keys=off;

ALTER TABLE Posts RENAME TO Posts_old;

create table Posts
(
    Id         INTEGER not null
        constraint PK_Posts
            primary key autoincrement,
    AuthorName TEXT,
    BlogId     INTEGER not null
        constraint FK_Posts_Blogs_BlogId
            references Blogs
            on delete cascade,
    Content    TEXT,
    Date       TEXT    not null,
    Title      TEXT
);

INSERT INTO Posts (Id, AuthorName, BlogId, Content, Date, Title) SELECT Id, AuthorName, BlogId, Content, Date, Title FROM Posts_old;

Drop table Author;
DROP TABLE Posts_old;

PRAGMA foreign_keys=on;