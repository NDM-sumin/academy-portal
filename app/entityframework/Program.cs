﻿namespace entityframework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string migrateName = $"migrate_database_{DateTime.Now:yyyy-MM-dd_HH:mm:ss}";
            string cmdText = $@"dotnet ef migrations add 'init db' -p 'entityframework/entityframework.csproj' -s 'api/api.csproj'";
            string updateCmd = "dotnet ef database update -p 'entityframework/entityframework.csproj' -s 'api/api.csproj'";
        }
    }
}
