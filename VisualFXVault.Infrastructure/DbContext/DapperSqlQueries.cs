namespace VisualFXVault.Infrastructure.DbContext;

public static class DapperSqlQueries
{
    public static class UserQueries
    {
        public const string Insert = @"
            INSERT INTO public.""Users""
            (""UserId"", ""Email"", ""Password"", ""Username"", ""Gender"")
            VALUES
            (@UserId, @Email, @Password, @Username, @Gender)";

        public const string GetById = @"
            SELECT * FROM public.""Users""
            WHERE ""UserId"" = @UserId";

        public const string GetByEmailAndPassword = @"
            SELECT * FROM public.""Users""
            WHERE ""Email"" = @Email AND ""Password"" = @Password";
    }
}