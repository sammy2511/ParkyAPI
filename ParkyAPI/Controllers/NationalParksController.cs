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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class NationalParksController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _npRepo = npRepo;
            _mapper = mapper;
        } 
        
        /// <summary>
        /// Get List of all National Park
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get National Park by National Park Id
        /// </summary>
        /// <param name="nationalParkid">Id of National Park</param>
        /// <returns></returns>
        [HttpGet("{nationalParkid:int}",Name = "GetNationalPark")]
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

        /// <summary>
        /// Update National Park
        /// </summary>
        /// <param name="nationalParkDTO">Request Body</param>
        /// <returns></returns>
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

            return CreatedAtRoute("GetNationalPark",new {nationalParkId = nationalParkObj.Id },nationalParkObj);
        }

        /// <summary>
        /// Update National Park
        /// </summary>
        /// <param name="nationalParkId">Id of National Park</param>
        /// <param name="nationalParkDTO">Request Body</param>
        /// <returns></returns>
        [HttpPatch("{nationalParkid:int}", Name = "UpdateNationalPark")]
        public IActionResult UpdateNationalPark(int nationalParkId, [FromBody] NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null || nationalParkId!= nationalParkDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_npRepo.UpdateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong while updating {nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete National Park by National Park ID
        /// </summary>
        /// <param name="nationalParkId">Id of National Park</param>
        /// <returns></returns>
        [HttpDelete("{nationalParkid:int}", Name = "DeleteNationalPark")]
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
          
            if (!_npRepo.NationalParkExists(nationalParkId))
            {
                return NotFound();
            }

            var obj = _npRepo.GetNationalPark(nationalParkId);

            if (!_npRepo.DeleteNationalPark(obj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting national park {obj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
