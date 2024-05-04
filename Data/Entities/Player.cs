using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Luck { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }

        public virtual ICollection<Match> Match { get; set; }
        public virtual ICollection<HistoryTournament> HistoryTournamentOfPlayer { get; set; }
    }

    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(26).IsRequired();
            builder.Property(x => x.Luck).HasColumnName("Luck").IsRequired();
            builder.Property(x => x.Strenght).HasColumnName("Strenght").IsRequired();
            builder.Property(x => x.Speed).HasColumnName("Speed").IsRequired();

            builder.HasMany(x => x.Match).WithOne(x => x.Winner);

            builder.HasMany(x => x.Match).WithOne(x => x.Loser);

            builder.HasMany(x => x.HistoryTournamentOfPlayer).WithOne(x => x.IdPlayerForeignKey);
        }
    }

}
