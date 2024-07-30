using Microsoft.EntityFrameworkCore;
using UltraPlay.ESports.Data;

namespace UltraPlay.ESports.Tests.Common
{
    public class ESportsDbContextFactory
    {
        public static ESportsDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ESportsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ESportsDbContext(options);
        }
    }
}
