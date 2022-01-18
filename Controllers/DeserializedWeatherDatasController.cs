#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
using WeatherAPI.Model;
using WeatherAPI.DAL;
using Microsoft.AspNetCore.SignalR;
using WeatherAPI.Hubs;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeserializedWeatherDatasController : ControllerBase
    {
        private IWeatherDataRepos _WeatherDataRepos;
        private readonly IUnitOfWork unitOfWork;
        //private readonly WeatherAPIContext _context;
        private readonly IHubContext<ShareHub, IShareHub> _hubContext;

        public DeserializedWeatherDatasController(IUnitOfWork UOW, IWeatherDataRepos WR, IHubContext<ShareHub, IShareHub> SH)
        {
            this._WeatherDataRepos = WR;
            this.unitOfWork = UOW;
            this._hubContext = SH;
        }

        // GET: api/DeserializedWeatherDatas
        [HttpGet]
        public async Task<ActionResult> GetWeatherData()
        {
            var rs = await _WeatherDataRepos.getAll();
            return Ok(rs);
        }

        // GET: api/DeserializedWeatherDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeserializedWeatherData>>  GetDeserializedWeatherData(int id)
        {
            var deserializedWeatherData = await _WeatherDataRepos.getById(id);
            if (deserializedWeatherData == null)
            {
                return NotFound();
            }
            return deserializedWeatherData;
        }

        // PUT: api/DeserializedWeatherDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeserializedWeatherData(int id, DeserializedWeatherData deserializedWeatherData)
        {
            if (id != deserializedWeatherData.Model_id)
            {
                return BadRequest();
            }
            await _WeatherDataRepos.update(deserializedWeatherData);
            try
            {
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            return Ok();
        }

        // POST: api/DeserializedWeatherDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeserializedWeatherData>> PostDeserializedWeatherData(DeserializedWeatherData deserializedWeatherData)
        {
            unitOfWork.CreateTransaction();
            await _WeatherDataRepos.insert(deserializedWeatherData);
            unitOfWork.Save();

            await _hubContext.Clients.All.ReceivedWeatherData(deserializedWeatherData); //      send change from hub to all subed clients

            return CreatedAtAction("GetDeserializedWeatherData", new { id = deserializedWeatherData.Model_id }, deserializedWeatherData);
        }

        // DELETE: api/DeserializedWeatherDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeserializedWeatherData(int id)
        {
            var deserializedWeatherData = _WeatherDataRepos.getById(id);
            if (deserializedWeatherData == null)
            {
                return NotFound();
            }

            await _WeatherDataRepos.delete(id);
            unitOfWork.Save();

            return Ok();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
    }
}
