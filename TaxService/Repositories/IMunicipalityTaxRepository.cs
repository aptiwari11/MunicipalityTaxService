using System;
using System.Collections.Generic;
using MunicipalityTaxService.Models;

namespace MunicipalityTaxService.Repositories
{
  public interface IMunicipalityTaxRecordRepository
  {
    void UpdateMunicipalityTaxRecord(MunicipalityTaxRecord MunicipalityTaxRecord);
    void CreateMunicipalityTaxRecord(MunicipalityTaxRecord MunicipalityTaxRecord);
    void CreateMunicipalityTaxRecordes(IEnumerable<MunicipalityTaxRecord> MunicipalityTaxRecord);
    MunicipalityTaxRecord GetMunicipalityTaxRecord(string MunicipalityName, DateTime date);
  }
}