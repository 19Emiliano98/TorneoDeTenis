using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Luck { get; set; }
        public int Hability { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }
        public int TimeReaction { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Match> PlayerWinner { get; set; }
        public virtual ICollection<Match> PlayerLoser { get; set; }
        public virtual ICollection<HistoryTournament> HistoryTournamentOfPlayer { get; set; }
    }

    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(26).IsRequired();
            builder.Property(x => x.Luck).HasColumnName("Luck");
            builder.Property(x => x.Hability).HasColumnName("Hability").IsRequired();
            builder.Property(x => x.Strenght).HasColumnName("Strenght").IsRequired();
            builder.Property(x => x.Speed).HasColumnName("Speed").IsRequired();
            builder.Property(x => x.TimeReaction).HasColumnName("TimeReaction").IsRequired();
            builder.Property(x => x.Gender).HasColumnName("Gender").IsRequired();

            builder.HasMany(x => x.PlayerWinner).WithOne(x => x.MatchWinner);

            builder.HasMany(x => x.PlayerLoser).WithOne(x => x.MatchLoser);

            builder.HasMany(x => x.HistoryTournamentOfPlayer).WithOne(x => x.IdPlayerForeignKey);
        }
    }
}
