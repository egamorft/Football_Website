using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRNFootballWebsite.API.Models
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
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.GoalNumber).HasColumnName("goal_number");

                entity.Property(e => e.Password)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Position)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account___role_i__2F10007B");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Account___status__300424B4");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Account___team_i__30F848ED");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.MatchesId)
                    .HasName("PK__Matches__85EA4E2F11D9736E");

                entity.Property(e => e.MatchesId).HasColumnName("matches_id");

                entity.Property(e => e.Datetime)
                    .HasColumnType("date")
                    .HasColumnName("datetime");

                entity.Property(e => e.Team1Id).HasColumnName("team1_id");

                entity.Property(e => e.Team2Id).HasColumnName("team2_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.MatchTeam1s)
                    .HasForeignKey(d => d.Team1Id)
                    .HasConstraintName("FK__Matches__team_id__31EC6D26");

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.MatchTeam2s)
                    .HasForeignKey(d => d.Team2Id)
                    .HasConstraintName("FK__Matches__team2_i__32E0915F");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK__Matches__tournam__30F848ED");
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
                entity.HasNoKey();

                entity.Property(e => e.MatchesId).HasColumnName("matches_id");

                entity.Property(e => e.PlayerGoalTeam1).HasColumnName("player_goal_team1");

                entity.Property(e => e.PlayerGoalTeam2).HasColumnName("player_goal_team2");

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
                    .WithMany()
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

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Stadium)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stadium");
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
