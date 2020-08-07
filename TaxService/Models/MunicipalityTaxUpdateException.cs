using System;

namespace MunicipalityTaxService.Models
{
  public class MunicipalityTaxRecordUpdateException : Exception
  {
    public MunicipalityTaxRecordUpdateException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
