using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class SportClubFaratechnoDBContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public SportClubFaratechnoDBContext()
        {
        }

        public SportClubFaratechnoDBContext(DbContextOptions<SportClubFaratechnoDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<MasterType> MasterType { get; set; }
        public DbSet<DetailType> DetailType { get; set; }
        public DbSet<UserExtraDetail> UserExtraDetail { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }
        public DbSet<Access> Access { get; set; }
        public DbSet<UserAccess> UserAccess { get; set; }


        public virtual DbSet<BuffetDetail> BuffetDetail { get; set; }
        public virtual DbSet<Cabinet> Cabinet { get; set; }

        public virtual DbSet<SalonBuffet> SalonBuffet { get; set; }
        public virtual DbSet<SalonCabinet> SalonCabinet { get; set; }
        public virtual DbSet<SalonEquipment> SalonEquipment { get; set; }
        public virtual DbSet<SalonSport> SalonSport { get; set; }
        //public virtual DbSet<SalonSportSessionType> SalonSportSessionType { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SessionDetail> SessionDetail { get; set; }
        public virtual DbSet<SessionUser> SessionUser { get; set; }
        public virtual DbSet<SessionUserExtraDetail> SessionUserExtraDetail { get; set; }
        public virtual DbSet<SessionUserTraffic> SessionUserTraffic { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<UserCabinet> UserCabinet { get; set; }
        public virtual DbSet<UserEquimentUsage> UserEquimentUsage { get; set; }
        public virtual DbSet<UserExtraInfo> UserExtraInfo { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<ClubSalon> ClubSalon { get; set; }
        public virtual DbSet<ClubCabinet> ClubCabinet { get; set; }

        public virtual DbSet<SessionUserExerciseProgram> SessionUserExerciseProgram { get; set; }

        public virtual DbSet<TrafficCabinet> TrafficCabinet { get; set; }

        public virtual DbSet<BuffetItemTypeItem> BuffetItemTypeItem { get; set; }
        public virtual DbSet<UserInsurance> UserInsurance { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
    }
}
