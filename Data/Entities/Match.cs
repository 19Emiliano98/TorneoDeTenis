using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int? IdWinner { get; set; }
        public int? IdLoser { get; set; }

        public virtual Player MatchWinner { get; set; }
        public virtual Player MatchLoser { get; set; }
        public virtual ICollection<MatchHistory> MatchHistoryCollection { get; set; }
    }

    public class MatchConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdWinner).HasColumnName("IdWinner").IsRequired();
            builder.Property(x => x.IdLoser).HasColumnName("IdLoser").IsRequired();

            builder.HasOne(a => a.MatchWinner)
                    .WithMany(a => a.PlayerWinner)
                    .HasForeignKey(x => x.IdWinner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Winner");

            builder.HasOne(a => a.MatchLoser)
                    .WithMany(a => a.PlayerLoser)
                    .HasForeignKey(x => x.IdLoser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Loser");

            builder.HasMany(x => x.MatchHistoryCollection).WithOne(x => x.MatchHistoryList);
        }
    }
}
