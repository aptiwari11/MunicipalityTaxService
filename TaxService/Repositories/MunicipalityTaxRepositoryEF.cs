using System;
using MunicipalityTaxService.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MunicipalityTaxService.Data;
using MunicipalityTaxService.Models;

namespace MunicipalityTaxService.Repositories
{
  public class MunicipalityTaxRecordRepositoryEF : IMunicipalityTaxRecordRepository
  {
    private readonly MunicipalityTaxRecordContext dbContext;

    public MunicipalityTaxRecordRepositoryEF(MunicipalityTaxRecordContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public MunicipalityTaxRecord GetMunicipalityTaxRecord(string MunicipalityName, DateTime date)
    {
      
        var TaxRateOnDate = dbContext.MunicipalityTaxRecordes
          .Where(mt => mt.MunicipalityName == MunicipalityName && mt.ScheduleStart <= date && mt.ScheduleEnd >= date)
          .OrderBy(mt => mt.Period)
          .FirstOrDefault();

        return TaxRateOnDate;    
    }

    public void CreateMunicipalityTaxRecord(MunicipalityTaxRecord MunicipalityTaxRecord)
    {
        dbContext.MunicipalityTaxRecordes.Add(MunicipalityTaxRecord);
      try
      {
        dbContext.SaveChanges();
      }
      catch (DbUpdateException e)
      {
        throw new MunicipalityTaxRecordUpdateException("Could not create MunicipalityTaxRecord  in database. ", e);
      }
    }

    public void CreateMunicipalityTaxRecordes(IEnumerable<MunicipalityTaxRecord> MunicipalityTaxRecordes)
    {
      dbContext.MunicipalityTaxRecordes.AddRange(MunicipalityTaxRecordes);
      try
      {
        dbContext.SaveChanges();
      }
      catch(DbUpdateException e)
      {
        throw new MunicipalityTaxRecordUpdateException("Could not create MunicipalityTaxRecord in database.", e);
      }
    }

    public void UpdateMunicipalityTaxRecord(MunicipalityTaxRecord MunicipalityTaxRecord)
    {
        dbContext.MunicipalityTaxRecordes.Update(MunicipalityTaxRecord);

      try
      {
        dbContext.SaveChanges();
      }
      catch (DbUpdateConcurrencyException e)
      {
        throw new MunicipalityTaxRecordUpdateException("Could not update MunicipalityTaxRecord in database.", e);
      }
    }
  }
}
