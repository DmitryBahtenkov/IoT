using System;
using System.Threading.Tasks;
using IoT.Api.System.Models;
using IoT.Api.System.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IoT.Api.Controllers
{
    [ApiController]
    [Route("data")]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository<DataDocument> _dataRepository;

        public DataController(IDataRepository<DataDocument> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataDocument document)
        {
            try
            {
                await _dataRepository.CreateDocument(document);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }
        
        [HttpGet("last")]
        public async Task<IActionResult> GetDate(DateTime date, string time)
        {
            try
            {
                var span = time.Split(":");
                
                return Ok(await _dataRepository.GetOne( 
                    Builders<DataDocument>.Filter.Eq(x=>x.Date, date) &
                    Builders<DataDocument>.Filter.Eq(x=>x.Hour, int.Parse(span[0]))));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("daterange")]
        public async Task<IActionResult> GetDateRange(string from, string to)
        {
            try
            {
                return Ok(await _dataRepository.GetMany(null));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}