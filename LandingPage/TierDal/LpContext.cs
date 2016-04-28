using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LandingPage.Models;
using System.Linq;
using System;
using System.Web.Caching;

namespace LandingPage.TierDal
{
    public class LpContext : DbContext
    {
        public LpContext() : base("LpContext")
        {
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Culture> Cultures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IQueryable<Content> GetContent(string cultureName, Cache cache)
        {
            LpContext db = new LpContext();
            string key = "db_cache";
            var content = (IQueryable<Content>)cache[key];

            if (content == null)
            {
                content = from record in db.Contents
                          where record.Culture.CultureName.ToLower() == cultureName
                          select record;

                cache.Insert(key, content, null, DateTime.MaxValue, TimeSpan.FromHours(1), CacheItemPriority.Normal, null);
            }

            return content;
        }
    }
}