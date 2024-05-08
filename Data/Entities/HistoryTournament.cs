﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public class HistoryTournament
    {
        public int Id { get; set; }
        public int? IdPlayer { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual Player IdPlayerForeignKey { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }

    public class HistoryTournamentConfig : IEntityTypeConfiguration<HistoryTournament>
    {
        public void Configure(EntityTypeBuilder<HistoryTournament> builder)
        {
            builder.ToTable("HistoryTournament");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdPlayer).HasColumnName("IdPlayer");
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.Date).HasColumnName("Date").IsRequired();

            builder.HasOne(a => a.IdPlayerForeignKey)
                    .WithMany(a => a.HistoryTournamentOfPlayer)
                    .HasForeignKey(x => x.IdPlayer)
                    .HasConstraintName("FK_HistoryTournament_Player");

            builder.HasMany(x => x.Matches).WithOne(x => x.TournamentPlayed);
        }
    }
}