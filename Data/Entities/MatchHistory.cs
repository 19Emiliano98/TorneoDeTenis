using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MatchHistory
    {
        public int Id { get; set; }
        public int IdTournament { get; set; }
        public int IdMatch { get; set; }

        public virtual Match MatchHistoryList { get; set; }
        public virtual ICollection<HistoryTournament> HistoryTournamentOfMatchHistory { get; set; }
    }

    public class MatchHistoryConfig : IEntityTypeConfiguration<MatchHistory>
    {
        public void Configure(EntityTypeBuilder<MatchHistory> builder)
        {
            builder.ToTable("MatchHistory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdTournament).HasColumnName("IdTournament").IsRequired();
            builder.Property(x => x.IdMatch).HasColumnName("IdMatch").IsRequired();

            builder.HasOne(a => a.MatchHistoryList)
                    .WithMany(a => a.MatchHistoryCollection)
                    .HasForeignKey(x => x.IdMatch)
                    .HasConstraintName("FK_MatchHistory_Match");

            builder.HasMany(x => x.HistoryTournamentOfMatchHistory).WithOne(x => x.MatchHistoryForeignKey);
        }
    }
}
