using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MunicipalityTaxService.Repositories;
using System;
using System.IO;
using MunicipalityTaxService.Models;
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

    [Route("AddTaxRateFromFile")]
    [HttpPost]
    public ActionResult AddTaxRateFromFile(IFormFile file)
    {
      using (var reader = new StreamReader(file.OpenReadStream()))
      {
        try
        {
                    // Processing the file. Need to create another service for it.
        }
        catch(Exception e) when (e is FormatException || e is MunicipalityTaxRecordUpdateException)
        {
          return BadRequest(e.Message);
        }
      }
      return Ok();
    }

    [Route("AddTaxRate")]
    [HttpPost]
    public ActionResult AddTaxRate([FromBody]MunicipalityTaxRecord MunicipalityTaxRecord)
    {
      if (!ModelState.IsValid)
        return BadRequest("The posted model is invalid");
        
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

    [Route("UpdateTaxRate")]
    [HttpPut]
    public ActionResult UpdateTaxRate([FromBody]MunicipalityTaxRecord MunicipalityTaxRecord)
    {
      if (!ModelState.IsValid)
        return BadRequest("The posted model is invalid");      
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
