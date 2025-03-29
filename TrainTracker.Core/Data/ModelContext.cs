using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainTracker.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavoriteStation> FavoriteStations { get; set; } = null!;
        public virtual DbSet<PageSetting> PageSettings { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Train> Trains { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##omarshuqairi5;PASSWORD=Test321;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##OMARSHUQAIRI5")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<FavoriteStation>(entity =>
            {
                entity.HasKey(e => e.FavoriteId)
                    .HasName("SYS_C008762");

                entity.ToTable("FAVORITE_STATIONS");

                entity.Property(e => e.FavoriteId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FAVORITE_ID");

                entity.Property(e => e.StationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATION_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.FavoriteStations)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FAV_STATION");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteStations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FAV_USER");
            });

            modelBuilder.Entity<PageSetting>(entity =>
            {
                entity.HasKey(e => e.PageId)
                    .HasName("SYS_C008770");

                entity.ToTable("PAGE_SETTINGS");

                entity.Property(e => e.PageId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAGE_ID");

                entity.Property(e => e.AboutUs)
                    .HasColumnType("CLOB")
                    .HasColumnName("ABOUT_US");

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_ADDRESS");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_EMAIL");

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_PHONE");

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FACEBOOK_LINK");

                entity.Property(e => e.InstagramLink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INSTAGRAM_LINK");

                entity.Property(e => e.LinkedinLink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LINKEDIN_LINK");

                entity.Property(e => e.LogoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_URL");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENTS");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENT_ID");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENT_AMOUNT");

                entity.Property(e => e.PaymentDate)
                    .HasPrecision(6)
                    .HasColumnName("PAYMENT_DATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_METHOD");

                entity.Property(e => e.TicketId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TICKET_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PAYMENT_TICKET");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PAYMENT_USER");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("STATIONS");

                entity.Property(e => e.StationId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATION_ID");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AREA");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.StationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STATION_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIALS");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TestimonialText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_TEXT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TESTIMONIAL_USER");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("TICKETS");

                entity.Property(e => e.TicketId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TICKET_ID");

                entity.Property(e => e.BookingDate)
                    .HasPrecision(6)
                    .HasColumnName("BOOKING_DATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_STATUS");

                entity.Property(e => e.TripId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIP_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TICKET_TRIP");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TICKET_USER");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("TRAINS");

                entity.Property(e => e.TrainId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRAIN_ID");

                entity.Property(e => e.DisabledSeatCapacity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DISABLED_SEAT_CAPACITY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RouteNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROUTE_NUMBER");

                entity.Property(e => e.TotalSeatCapacity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SEAT_CAPACITY");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("TRIPS");

                entity.Property(e => e.TripId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_ID");

                entity.Property(e => e.DepartureTime)
                    .HasPrecision(6)
                    .HasColumnName("DEPARTURE_TIME");

                entity.Property(e => e.EndStationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("END_STATION_ID");

                entity.Property(e => e.StartStationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("START_STATION_ID");

                entity.Property(e => e.TicketPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TICKET_PRICE");

                entity.Property(e => e.TrainId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRAIN_ID");

                entity.Property(e => e.TripDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TRIP_DESCRIPTION");

                entity.HasOne(d => d.EndStation)
                    .WithMany(p => p.TripEndStations)
                    .HasForeignKey(d => d.EndStationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_END_STATION");

                entity.HasOne(d => d.StartStation)
                    .WithMany(p => p.TripStartStations)
                    .HasForeignKey(d => d.StartStationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_START_STATION");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.TrainId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TRIP_TRAIN");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.Email, "SYS_C008728")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_ROLE");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("SYS_C008733");

                entity.ToTable("USER_PROFILE");

                entity.HasIndex(e => e.UserId, "SYS_C008734")
                    .IsUnique();

                entity.Property(e => e.ProfileId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROFILE_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PROFILE_IMAGE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PROFILE_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
