using Microsoft.EntityFrameworkCore;
using MunicipalityTaxService.Models;

namespace MunicipalityTaxService.Data
{
  public class MunicipalityTaxRecordContext : DbContext
  {

    public MunicipalityTaxRecordContext(DbContextOptions<MunicipalityTaxRecordContext> options)
        : base(options)
    {
    }

    public DbSet<MunicipalityTaxRecord> MunicipalityTaxRecordes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<MunicipalityTaxRecord>()
        .ToTable("MunicipalityTaxRecord")
        .HasKey(o => new { o.MunicipalityName, o.Period, o.ScheduleStart });
    }
  }
}
