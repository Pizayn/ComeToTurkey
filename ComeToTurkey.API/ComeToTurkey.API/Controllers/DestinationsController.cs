using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Data;
using ComeToTurkey.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeToTurkey.API.Controllers
{
    [Produces("application/json")]
    [Route("api/destinations")]
    public class DestinationsController : Controller
    {
        private IRepository _repository;

        public DestinationsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async  Task<IActionResult> GetDestinations()
        {
            var destinatios = await _repository.GetList<Destination>();
            return Ok(destinatios);
        }

        
    }
}