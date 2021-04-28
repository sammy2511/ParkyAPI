using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.DTOs;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;

        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        } 
        
        [HttpGet]

        public IActionResult GetNationaParks()
        {
            var objList = _npRepo.GetNationalParks();

            var objDto = new List<NationalParkDTO>();

            foreach(var obj in objList)
            {
                objDto.Add(_mapper.Map<NationalParkDTO>(obj));
            }
            return Ok(objDto);
        }

        [HttpGet("{nationalParkid:int}")]
        public IActionResult GetNationalPark(int nationalParkid)
        {
            var obj = _npRepo.GetNationalPark(nationalParkid);
            if(obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<NationalParkDTO>(obj);

            return Ok(objDto);

        }

        [HttpPost]
        public IActionResult CreateNationaPark([FromBody] NationalParkDTO nationalParkDTO)
        {
            if(nationalParkDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_npRepo.NationalParkExists(nationalParkDTO.Name))
            {
                ModelState.AddModelError("", "National Park Already Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_npRepo.CreateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong while adding {nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}
