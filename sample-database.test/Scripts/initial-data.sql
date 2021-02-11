insert into "Blogs" ("Name", "Tagline")
values ('My Life', 'Making my life look more exciting than it is');

insert into "Posts" ("Title", "Content", "BlogId", "AuthorName", "Date")
values ('I did a thing', 'witty writing here', (select max("Blogs"."Id") from "Blogs"), 'Andy Watt', '2011-03-14'),
       ('Lockdown Fun', 'Banana Bread is delicious', (select max("Blogs"."Id") from "Blogs"), 'Andy Watt', '2012-03-14');

insert into "Blogs" ("Name", "Tagline")
values ('Coding Things', 'Rockstar Coders');

insert into "Posts" ("Title", "Content", "BlogId", "AuthorName", "Date")
values ('Vim for fun and profit', 'content', (select max("Blogs"."Id") from "Blogs"), 'Richard Whiteley', '2013-03-14'),
       ('Are you also stuck in Vim? Send Help', 'content', (select max("Blogs"."Id") from "Blogs"), 'Carol Vorderman', '2014-03-14');