insert into Author (DisplayName) select distinct AuthorName from Posts;

update Posts
set AuthorId = (
    select Author.Id
    from Author
    where Posts.AuthorName = Author.DisplayName);