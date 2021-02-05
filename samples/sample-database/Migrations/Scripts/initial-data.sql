insert into Blogs (Name, Tagline)
values ('My Life', 'Making my life look more exciting than it is');

insert into Posts (Title, Content, BlogId, AuthorName)
values ('I did a fun thing', 'witty writing here', (select max(Blogs.Id) from Blogs), 'Andy Watt'),
       ('Wild Scenes in lockdown', 'Banana Bread is delicious', (select max(Blogs.Id) from Blogs), 'Andy Watt');

insert into Blogs (Name, Tagline)
values ('Mad Coding Skillz', 'Showing off coding skills that I totally didnt google');

insert into Posts (Title, Content, BlogId, AuthorName)
values ('Vim for fun and profit', 'content', (select max(Blogs.Id) from Blogs), 'Richard Whiteley'),
       ('Are you also stuck in Vim? Send Help', 'content', (select max(Blogs.Id) from Blogs), 'Carol Vorderman');