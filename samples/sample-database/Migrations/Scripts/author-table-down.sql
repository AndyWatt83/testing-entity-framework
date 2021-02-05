update "Posts"
set "AuthorName" = (
    select "Authors"."DisplayName"
    from "Authors"
    where "Posts"."AuthorId" = "Authors"."Id");