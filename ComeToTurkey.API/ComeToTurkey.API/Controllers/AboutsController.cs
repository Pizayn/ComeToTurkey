using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComeToTurkey.API.Data;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeToTurkey.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Abouts")]
    public class AboutsController : Controller
    {
        private IRepository _repository;
        private IMapper _mapper;

        public AboutsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams =await _repository.GetList<Team>();
            var about = await _repository.GetAbout();
            AboutPagesToReturnDto aboutPagesToReturn = new AboutPagesToReturnDto();
            aboutPagesToReturn.Teams = teams.ToList();
            aboutPagesToReturn.AboutDescription = about.Description;
          
            return Ok(aboutPagesToReturn);
        }
    }
}