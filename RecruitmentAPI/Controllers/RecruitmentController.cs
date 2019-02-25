using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Domain.Entity;
using Recruitment.Domain.Services;
using RecruitmentAPI.Dtos;
using RecruitmentAPI.Mappers;

namespace RecruitmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : Controller
    {
        private readonly IService _service;
        //private readonly ICandidateMapper _mapper;

        public RecruitmentController (IService service)
        {
            _service = service;
            //_mapper = mapper;
        }

        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetCandidates()
        {
            var result = await _service.GetAllCandidatesAsync();
            return result == null || ((List<Candidates>)result).Count < 0
              ? (IActionResult)NoContent()
              : (IActionResult)Ok(result);
        }

        [Route("CandidateDetail")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var result = await _service.GetCandidateById(id);
            return result == null
                ? (IActionResult)NoContent()
                : (IActionResult)Ok(result);
        }

        [Route("AddCandidate")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> AddCandidate (Candidates candidate)
        {
            //if(candidateDto == null)
            //{
            //    return BadRequest("Invalid request");
            //}

            if(candidate == null)
            {
                return BadRequest("Invalid Request");
            }

            //var addCandidate = _mapper.MapCreationCandidateDtoToEntity(candidateDto);
            await _service.AddCandidate(candidate);
            var result = await _service.GetAllCandidatesAsync();
            return result == null || ((List<Candidates>)result).Count < 0
              ? (IActionResult)NoContent()
              : (IActionResult)Ok(result);
        }

        [Route("UpdateCandidate")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateCandidate(Candidates candidate)
        {
            if(candidate == null)
            {
                return BadRequest();
            }
            else
            {
               await _service.UpdateCandidate(candidate);
                var result = await _service.GetAllCandidatesAsync();
                return result == null || ((List<Candidates>)result).Count < 0
                  ? (IActionResult)NoContent()
                  : (IActionResult)Ok(result);
            }
        }

        [Route("DeleteCandidate")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            else
            {
                var result= await _service.DeleteCandidate(id);
                return (IActionResult)Ok(result);
            }
        }
    }
}
