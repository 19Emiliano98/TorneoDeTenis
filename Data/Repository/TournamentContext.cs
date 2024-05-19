using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new HistoryTournamentConfig());
            builder.ApplyConfiguration(new MatchConfig());
            builder.ApplyConfiguration(new PlayerConfig());
            builder.ApplyConfiguration(new PlayerConfig());
            builder.ApplyConfiguration(new UserConfig());
        }
    }
}
