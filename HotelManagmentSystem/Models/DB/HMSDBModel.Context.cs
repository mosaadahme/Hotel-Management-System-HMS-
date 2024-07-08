using Microsoft.EntityFrameworkCore;

namespace HotelManagmentSystem.Models.DB
{
    public class HMSDBContext : DbContext
    {
        public HMSDBContext( )  
        {
        }

        public HMSDBContext(DbContextOptions<HMSDBContext> options) : base(options)
        {
            
        }

        public DbSet<tbl_booking> tbl_booking { get; set; }
        public DbSet<tbl_booking_status> tbl_booking_status { get; set; }
        public DbSet<tbl_payment> tbl_payment { get; set; }
        public DbSet<tbl_payment_type> tbl_payment_type { get; set; }
        public DbSet<tbl_room> tbl_room { get; set; }
        public DbSet<tbl_room_type> tbl_room_type { get; set; }
        public DbSet<tbl_user> tbl_user { get; set; }
        public DbSet<tbl_user_level> tbl_user_level { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
