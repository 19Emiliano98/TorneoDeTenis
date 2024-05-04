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

        public DbSet<HistoryTournament> historyTournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchHistory> MatchHistories { get; set; }
        public DbSet<Player> Plkayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new HistoryTournamentConfig());
            modelBuilder.ApplyConfiguration(new MatchConfig());
            modelBuilder.ApplyConfiguration(new MatchHistoryConfig());
            modelBuilder.ApplyConfiguration(new PlayerConfig());

        }

    }



}
