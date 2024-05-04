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
        public int IdWinner { get; set; }
        public int IdLoser { get; set; }

        public virtual Player Winner { get; set; }
        public virtual Player Loser { get; set; }
        public virtual ICollection<MatchHistory> MatchHistory { get; set; }
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

            builder.HasOne(a => a.Winner)
                    .WithMany(a => a.Match)
                    .HasForeignKey(x => x.IdWinner)
                    .HasConstraintName("FK_Match_Player_Winner");

            builder.HasOne(a => a.Loser)
                    .WithMany(a => a.Match)
                    .HasForeignKey(x => x.IdLoser)
                    .HasConstraintName("FK_Match_Player_Loser");

            builder.HasMany(x => x.MatchHistory).WithOne(x => x.Match);
        }
    }
}
