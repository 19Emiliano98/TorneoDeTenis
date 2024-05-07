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

        public int Hability { get; set; }
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
            builder.Property(x => x.Luck).HasColumnName("Luck").IsRequired();
            builder.Property(x => x.Strenght).HasColumnName("Strenght").IsRequired();
            builder.Property(x => x.Speed).HasColumnName("Speed").IsRequired();

            builder.HasMany(x => x.PlayerWinner).WithOne(x => x.MatchWinner);

            builder.HasMany(x => x.PlayerLoser).WithOne(x => x.MatchLoser);

            //builder.HasData(
            //    new Player
            //    {
            //        Id = 1,
            //        Name = "Facundo Villalobo",
            //        Luck = 0,
            //        Strenght = 80,
            //        Speed = 32
            //    },
            //    new Player
            //    {
            //        Id = 2,
            //        Name = "Matias Corredera",
            //        Luck = 0,
            //        Strenght = 60,
            //        Speed = 40
            //    },
            //    new Player
            //    {
            //        Id = 3,
            //        Name = "Lautaro De Simeone",
            //        Luck = 0,
            //        Strenght = 61,
            //        Speed = 39
            //    },
            //    new Player
            //    {
            //        Id = 4,
            //        Name = "Emiliano Caballero",
            //        Luck = 0,
            //        Strenght = 65,
            //        Speed = 34
            //    },
            //    new Player
            //    {
            //        Id = 5,
            //        Name = "Carlos Palladino",
            //        Luck = 0,
            //        Strenght = 59,
            //        Speed = 35
            //    },
            //    new Player
            //    {
            //        Id = 6,
            //        Name = "Gustavo Lucci",
            //        Luck = 0,
            //        Strenght = 69,
            //        Speed = 31
            //    },
            //    new Player
            //    {
            //        Id = 7,
            //        Name = "Roque Olguin",
            //        Luck = 0,
            //        Strenght = 49,
            //        Speed = 70
            //    },
            //    new Player
            //    {
            //        Id = 8,
            //        Name = "Joaquin Martinez",
            //        Luck = 0,
            //        Strenght = 50,
            //        Speed = 47
            //    }
            //);

        }
    }
}
