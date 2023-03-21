﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class ProjectPRN231Context : DbContext
    {
        public ProjectPRN231Context()
        {
        }

        public ProjectPRN231Context(DbContextOptions<ProjectPRN231Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<MatchScorer> MatchScorers { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Statistic> Statistics { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(local);database=ProjectPRN231;uid=sa;pwd=abczxc123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FullName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account___role_i__2C3393D0");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account___status__2D27B809");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.MatchesId)
                    .HasName("PK__Matches__85EA4E2F11D9736E");

                entity.Property(e => e.MatchesId).HasColumnName("matches_id");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Team1Id).HasColumnName("team1_id");

                entity.Property(e => e.Team2Id).HasColumnName("team2_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.MatchTeam1s)
                    .HasForeignKey(d => d.Team1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__team_id__31EC6D26");

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.MatchTeam2s)
                    .HasForeignKey(d => d.Team2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__team2_i__32E0915F");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__tournam__30F848ED");
            });

            modelBuilder.Entity<MatchScorer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Match_Scorers");

                entity.Property(e => e.IsOwnGoal).HasColumnName("isOwnGoal");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.ScoreMinutes).HasColumnName("score_minutes");

                entity.Property(e => e.StatisticId).HasColumnName("statistic_id");

                entity.HasOne(d => d.Player)
                    .WithMany()
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Scorers_Players");

                entity.HasOne(d => d.Statistic)
                    .WithMany()
                    .HasForeignKey(d => d.StatisticId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Scorers_Statistics");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.Assist).HasColumnName("assist");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Goal).HasColumnName("goal");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("img")
                    .HasDefaultValueSql("('unknownPlayer.png')");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nationality");

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("player_name");

                entity.Property(e => e.Position)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Players_Team");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_description");
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.Property(e => e.StatisticId).HasColumnName("statistic_id");

                entity.Property(e => e.MatchesId).HasColumnName("matches_id");

                entity.Property(e => e.Team1Corner).HasColumnName("team1_corner");

                entity.Property(e => e.Team1Goal).HasColumnName("team1_goal");

                entity.Property(e => e.Team1Ontarget).HasColumnName("team1_ontarget");

                entity.Property(e => e.Team1Possession).HasColumnName("team1_possession");

                entity.Property(e => e.Team1Shoot).HasColumnName("team1_shoot");

                entity.Property(e => e.Team2Corner).HasColumnName("team2_corner");

                entity.Property(e => e.Team2Goal).HasColumnName("team2_goal");

                entity.Property(e => e.Team2Ontarget).HasColumnName("team2_ontarget");

                entity.Property(e => e.Team2Possession).HasColumnName("team2_possession");

                entity.Property(e => e.Team2Shoot).HasColumnName("team2_shoot");

                entity.HasOne(d => d.Matches)
                    .WithMany(p => p.Statistics)
                    .HasForeignKey(d => d.MatchesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match_Sta__match__33D4B598");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_description");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("logo")
                    .HasDefaultValueSql("(N'unknownClub.png')");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Site)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("site");

                entity.Property(e => e.Stadium)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stadium");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_Tournament");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
