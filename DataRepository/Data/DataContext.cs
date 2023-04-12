using Microsoft.EntityFrameworkCore;
using WebSerino.Data;

namespace DataRepository.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activation> Activations { get; set; }

        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Firmware> Firmwares { get; set; }

        public virtual DbSet<Isssue> Isssues { get; set; }

        public virtual DbSet<Keyfob> Keyfobs { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<Otp> Otps { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<Share> Shares { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserTemp> UserTemps { get; set; }

        public virtual DbSet<Verification> Verifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=192.168.1.44;Database=thinkr;User Id=pitechThinkr;password=pitech123;Trusted_Connection=False;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_device");

                entity.ToTable("activation");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.DeviceType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("device_type");
                entity.Property(e => e.Disabled).HasColumnName("disabled");
                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("serial_number");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_device_1");

                entity.ToTable("device");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Avatar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasColumnName("avatar");
                entity.Property(e => e.Battery)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("battery");
                entity.Property(e => e.DateActivated).HasColumnName("date_activated");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.DateDisabled).HasColumnName("date_disabled");
                entity.Property(e => e.DeviceType).HasColumnName("device_type");
                entity.Property(e => e.Disabled)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("disabled");
                entity.Property(e => e.Favorite).HasColumnName("favorite");
                entity.Property(e => e.FirmwareVersion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("firmware_version");
                entity.Property(e => e.HardwareVersion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("hardware_version");
                entity.Property(e => e.HasBridge).HasColumnName("has_bridge");
                entity.Property(e => e.MacAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mac_address");
                entity.Property(e => e.Nickname)
                    .HasMaxLength(200)
                    .HasColumnName("nickname");
                entity.Property(e => e.PrivateKey)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasColumnName("private_key");
                entity.Property(e => e.Seed)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("seed");
                entity.Property(e => e.SeedCounter).HasColumnName("seed_counter");
                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("serial_number");
                entity.Property(e => e.Ssid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ssid");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Wifi).HasColumnName("wifi");

                entity.HasOne(d => d.User).WithMany(p => p.Devices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_device_user");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_device_log");

                entity.ToTable("event");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Content)
                    .HasMaxLength(150)
                    .HasColumnName("content");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.DeviceId).HasColumnName("device_id");
                entity.Property(e => e.EventCode).HasColumnName("event_code");
                entity.Property(e => e.EventDate).HasColumnName("event_date");
                entity.Property(e => e.EventNumber).HasColumnName("event_number");
                entity.Property(e => e.LayoutType).HasColumnName("layout_type");
                entity.Property(e => e.Sender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sender");
                entity.Property(e => e.SenderId).HasColumnName("sender_id");
                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("serial_number");
                entity.Property(e => e.Source)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("source");
                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Device).WithMany(p => p.Events)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_event_device");
            });

            modelBuilder.Entity<Firmware>(entity =>
            {
                entity.ToTable("firmware");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AccountType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("account_type");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Enabled).HasColumnName("enabled");
                entity.Property(e => e.File1)
                    .IsUnicode(false)
                    .HasColumnName("file1");
                entity.Property(e => e.File2)
                    .IsUnicode(false)
                    .HasColumnName("file2");
                entity.Property(e => e.File3)
                    .IsUnicode(false)
                    .HasColumnName("file3");
                entity.Property(e => e.File4)
                    .IsUnicode(false)
                    .HasColumnName("file4");
                entity.Property(e => e.Major).HasColumnName("major");
                entity.Property(e => e.Minor).HasColumnName("minor");
                entity.Property(e => e.Product)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("product");
                entity.Property(e => e.RequiredMajor).HasColumnName("required_major");
                entity.Property(e => e.RequiredMinor).HasColumnName("required_minor");
                entity.Property(e => e.RequiredRevision).HasColumnName("required_revision");
                entity.Property(e => e.Revision).HasColumnName("revision");
                entity.Property(e => e.Type1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type1");
                entity.Property(e => e.Type2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type2");
                entity.Property(e => e.Type3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type3");
                entity.Property(e => e.Type4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type4");
                entity.Property(e => e.VersionNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Version_Number");
            });

            modelBuilder.Entity<Keyfob>(entity =>
            {
                entity.ToTable("keyfob");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DeviceId).HasColumnName("device_id");
                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("serial_number");

                entity.HasOne(d => d.Device).WithMany(p => p.Keyfobs)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_keyfob_device");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_user_log");

                entity.ToTable("log");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("action");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.Info)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("info");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_log_user");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("country_code");
                entity.Property(e => e.FailedAttempts).HasColumnName("failed_attempts");
                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ip_address");
                entity.Property(e => e.LastTried)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("last_tried");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("otp");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("country_code");
                entity.Property(e => e.DateCreated).HasColumnName("date_created");
                entity.Property(e => e.DateExpires).HasColumnName("date_expires");
                entity.Property(e => e.DateUsed).HasColumnName("date_used");
                entity.Property(e => e.Invalidated).HasColumnName("invalidated");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
                entity.Property(e => e.SmsNetwork)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sms_network");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AppVersion)
                    .HasMaxLength(15)
                    .HasColumnName("app_version");
                entity.Property(e => e.ChipName)
                    .HasMaxLength(20)
                    .HasColumnName("chip_name");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");
                entity.Property(e => e.DateDisabled)
                    .HasColumnType("datetime")
                    .HasColumnName("date_disabled");
                entity.Property(e => e.DateExpires)
                    .HasColumnType("datetime")
                    .HasColumnName("date_expires");
                entity.Property(e => e.DatePasswordverified)
                    .HasColumnType("datetime")
                    .HasColumnName("date_passwordverified");
                entity.Property(e => e.Disabled).HasColumnName("disabled");
                entity.Property(e => e.FaceId).HasColumnName("face_id");
                entity.Property(e => e.Lang)
                    .HasMaxLength(40)
                    .HasColumnName("lang");
                entity.Property(e => e.LastActive)
                    .HasColumnType("datetime")
                    .HasColumnName("last_active");
                entity.Property(e => e.OsName)
                    .HasMaxLength(30)
                    .HasColumnName("os_name");
                entity.Property(e => e.OsVersion)
                    .HasMaxLength(20)
                    .HasColumnName("os_version");
                entity.Property(e => e.PhoneModel)
                    .HasMaxLength(50)
                    .HasColumnName("phone_model");
                entity.Property(e => e.Processors)
                    .HasMaxLength(30)
                    .HasColumnName("processors");
                entity.Property(e => e.Retina).HasColumnName("retina");
                entity.Property(e => e.SdkVersion)
                    .HasMaxLength(20)
                    .HasColumnName("sdk_version");
                entity.Property(e => e.Sessionkey)
                    .HasMaxLength(200)
                    .HasColumnName("sessionkey");
                entity.Property(e => e.TotalRam).HasColumnName("total_ram");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Vendor)
                    .HasMaxLength(20)
                    .HasColumnName("vendor");

                entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_session_user");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("setting");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Share>(entity =>
            {
                entity.ToTable("share");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Accepted).HasColumnName("accepted");
                entity.Property(e => e.DateAccepted).HasColumnName("date_accepted");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.DateDisabled).HasColumnName("date_disabled");
                entity.Property(e => e.DeviceId).HasColumnName("device_id");
                entity.Property(e => e.Disabled).HasColumnName("disabled");
                entity.Property(e => e.Favorite).HasColumnName("favorite");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.PermissionControl)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("permission_control");
                entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
                entity.Property(e => e.Secret).HasColumnName("secret");
                entity.Property(e => e.Seed)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("seed");
                entity.Property(e => e.Signature).HasColumnName("signature");
                entity.Property(e => e.UserIndex).HasColumnName("userIndex");

                entity.HasOne(d => d.Device).WithMany(p => p.Shares)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_share_device");

                entity.HasOne(d => d.Recipient).WithMany(p => p.Shares)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_share_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_account");

                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("account_id");
                entity.Property(e => e.AccountType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("account_type");
                entity.Property(e => e.Avatar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("avatar");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("country_code");
                entity.Property(e => e.DateCreated).HasColumnName("date_created");
                entity.Property(e => e.DateDeleted).HasColumnName("date_deleted");
                entity.Property(e => e.DateDeleterequested).HasColumnName("date_deleterequested");
                entity.Property(e => e.DeleteRequested).HasColumnName("delete_requested");
                entity.Property(e => e.Deleted).HasColumnName("deleted");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<UserTemp>(entity =>
            {
                entity.ToTable("UserTemp");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");
                entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Verification>(entity =>
            {
                entity.ToTable("verification");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("country_code");
                entity.Property(e => e.DateAdded).HasColumnName("date_added");
                entity.Property(e => e.DateUsed).HasColumnName("date_used");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
                entity.Property(e => e.Success).HasColumnName("success");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
