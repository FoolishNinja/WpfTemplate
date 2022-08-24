using Microsoft.EntityFrameworkCore;
using System;

namespace WpfTemplate.Database
{
    public class ContextBuilder
    {
        public static DatabaseContext CreateDbContext()
        {
            ServerVersion sv = ServerVersion.Create(new Version(10, 8, 3), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb);

            DbContextOptionsBuilder<DatabaseContext> optionsBuilder
              = new DbContextOptionsBuilder<DatabaseContext>()
            .UseMySql($"Server={DatabaseCredentials.HOST};Port={DatabaseCredentials.PORT};Database={DatabaseCredentials.DATABASE_NAME};User={DatabaseCredentials.USER};Password={DatabaseCredentials.PASSWORD};TreatTinyAsBoolean=true;DateTimeKind=Utc;Convert Zero Datetime=true;", sv);

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}