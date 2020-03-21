using Microsoft.EntityFrameworkCore;
using Cybernews.DesignTimeDbContextFactoryBase;

namespace Cybernews.DAL.Data
{
    public class CybernewsContextFactory : DesignTimeDbContextFactoryBase<CybernewsContext>
    {
        protected override CybernewsContext CreateInstance(
            DbContextOptions<CybernewsContext> options)
        {
            return new CybernewsContext(options);
        }
    }
}