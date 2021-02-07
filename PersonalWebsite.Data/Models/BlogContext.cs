using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonalWebsite.Data.Models.Application;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<BlogCrossPost> BlogCrossPosts { get; set; }
        public virtual DbSet<BlogTag> BlogTags { get; set; }
        public virtual DbSet<BlogTag1> BlogTags1 { get; set; }
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<ExperienceInfo> ExperienceInfos { get; set; }
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=blog;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(AppSettings.Database.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccentColour)
                    .IsUnicode(false)
                    .HasColumnName("accentColour");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.HeaderImage).HasColumnName("headerImage");

                entity.Property(e => e.Hidden)
                    .HasColumnName("hidden")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemType)
                    .IsUnicode(false)
                    .HasColumnName("itemType");

                entity.Property(e => e.Summary).HasColumnName("summary");

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.TitleTextColour)
                    .IsUnicode(false)
                    .HasColumnName("titleTextColour");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsUnicode(false)
                    .HasColumnName("itemType");

                entity.Property(e => e.Name)
                    .IsUnicode(true)
                    .HasColumnName("itemName");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sortOrder");
            });

            modelBuilder.Entity<BlogCrossPost>(entity =>
            {
                entity.ToTable("BlogCrossPost");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlogId).HasColumnName("blogId");

                entity.Property(e => e.BlogUrl)
                    .IsUnicode(false)
                    .HasColumnName("blogUrl");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IconCss).HasColumnName("iconCss");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogCrossPosts)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_BlogCrossPost_Blog");
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.ToTable("BlogTag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<BlogTag1>(entity =>
            {
                entity.ToTable("BlogTags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlogId).HasColumnName("blogId");

                entity.Property(e => e.BlogTagId).HasColumnName("blogTagId");
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Details)
                    .IsUnicode(false)
                    .HasColumnName("details");

                entity.Property(e => e.EducationType)
                    .IsUnicode(false)
                    .HasColumnName("educationType");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Yr).HasColumnName("yr");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.CompanyLine)
                    .IsUnicode(false)
                    .HasColumnName("companyLine");

                entity.Property(e => e.CompanyLocation).HasColumnName("companyLocation");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnName("details");

                entity.Property(e => e.SortOrder).HasColumnName("sortOrder");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<ExperienceInfo>(entity =>
            {
                entity.ToTable("ExperienceInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnName("details");

                entity.Property(e => e.ExperienceId).HasColumnName("experienceId");

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Experience)
                    .WithMany(p => p.ExperienceInfos)
                    .HasForeignKey(d => d.ExperienceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExperienceInfo_Experience");
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Details)
                    .IsUnicode(false)
                    .HasColumnName("details");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
