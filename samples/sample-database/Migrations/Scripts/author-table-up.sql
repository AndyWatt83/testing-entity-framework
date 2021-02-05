insert into "Authors" ("DisplayName") select distinct "AuthorName" from "Posts";

update "Posts"
set "AuthorId" = (
    select "Authors"."Id"
    from "Authors"
    where "Posts"."AuthorName" = "Authors"."DisplayName");