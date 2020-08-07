using System;

namespace MunicipalityTaxService.Models
{
  public class MunicipalityTaxRecord
  {
    public DateTime ScheduleStart { get; set; }
    public DateTime ScheduleEnd { get; set; }
    public string MunicipalityName { get; set; }
    public TimePeriod Period { get; set; }
    public Decimal TaxRate { get; set; }
    }
}
