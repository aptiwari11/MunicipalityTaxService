using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MunicipalityTaxService.Repositories;
using System;
using MunicipalityTaxService.Models;

namespace MunicipalityTaxService.Controllers
{
  public class MunicipalityTaxRecordController : Controller
  {
    private readonly IMunicipalityTaxRecordRepository MunicipalityTaxRecordRepository;

    public MunicipalityTaxRecordController(IMunicipalityTaxRecordRepository MunicipalityTaxRecordRepository)
    {
      this.MunicipalityTaxRecordRepository = MunicipalityTaxRecordRepository;
    }

    [Route("AddMTax")]
    [HttpPost]
    public ActionResult AddMTax([FromBody]MunicipalityTaxRecord MunicipalityTaxRecord)
    {
      if (!ModelState.IsValid)
        return BadRequest("The model is invalid");
        
      try
        {
          MunicipalityTaxRecordRepository.CreateMunicipalityTaxRecord(MunicipalityTaxRecord);
        }        
        catch (MunicipalityTaxRecordUpdateException e)
        {
          return BadRequest(e.Message);
        }

      return Ok();
    }

    [Route("UpdateMTax")]
    [HttpPut]
    public ActionResult UpdateMTax([FromBody]MunicipalityTaxRecord MunicipalityTaxRecord)
    {
      if (!ModelState.IsValid)
        return BadRequest("The model is invalid");      
      try
      {
        MunicipalityTaxRecordRepository.UpdateMunicipalityTaxRecord(MunicipalityTaxRecord);
      }
      catch (MunicipalityTaxRecordUpdateException e)
      {
        return BadRequest(e.Message);
      }

      return Ok();
    }

    [Route("GetTaxRate")]
    [HttpGet]
    public ActionResult GetTaxRate(string MunicipalityName, DateTime TaxRateDate)
    {
      var TaxRate = MunicipalityTaxRecordRepository.GetMunicipalityTaxRecord(MunicipalityName, TaxRateDate);
      if (TaxRate == null)
        return NotFound("No Municipality tax record was found.");
      
      return Ok(TaxRate.TaxRate);
    }
  }
}
