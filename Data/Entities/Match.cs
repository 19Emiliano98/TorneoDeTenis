using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int IdTournament { get; set; }
        public int? IdWinner { get; set; }
        public int? IdLoser { get; set; }

        public virtual HistoryTournament TournamentPlayed { get; set; }
        public virtual Player MatchWinner { get; set; }
        public virtual Player MatchLoser { get; set; }
    }

    public class MatchConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdTournament).HasColumnName("IdHistoryMatch").IsRequired();
            builder.Property(x => x.IdWinner).HasColumnName("IdWinner").IsRequired();
            builder.Property(x => x.IdLoser).HasColumnName("IdLoser").IsRequired();

            builder.HasOne(a => a.TournamentPlayed)
                    .WithMany(a => a.Matches)
                    .HasForeignKey(x => x.IdTournament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Tournament");

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
        }
    }
}
