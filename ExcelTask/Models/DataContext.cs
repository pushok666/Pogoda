using Microsoft.EntityFrameworkCore;


namespace ExcelTask.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):
            base(options){}
        public DbSet<DateData>? DateDatas { get; set; }
        public DbSet<HourAndData>? HourAndDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DateData>()
                .ToTable("Dates");
            modelBuilder.Entity<HourAndData>(
                eb =>
                {
                    eb.Property(p => p.Id).HasColumnName("Id");
                    eb.Property(p => p.IdDate).HasColumnName("IdDate");
                    eb.ToTable("Data");
                    eb.HasOne<DateData>(d => d.DateData)
                        .WithMany(h => h.HourAndDatas)
                        .HasForeignKey(fk => fk.IdDate);
                    
                }
            );
                
            
                
        }
    }
}