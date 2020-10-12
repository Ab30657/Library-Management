using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BLL.EF
{
    class LibraryContextFactory: IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            var connectionString = @"server=.;database=LibrarySystem;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;";
            optionsBuilder.UseSqlServer(
                    connectionString,
                    options => options.EnableRetryOnFailure())
#pragma warning disable CS0618 // Type or member is obsolete
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
#pragma warning restore CS0618 // Type or member is obsolete
            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
