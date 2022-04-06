using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository,
                                   IMapper mapper
        )
        {
            _repository = platformRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allplatforms")]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.Write("Getting Platforms");
            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(_repository.GetAllPlatforms()));
        }

        /// <summary>
        /// Get Platform By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{platformId}", Name = "platformById")]
        [Route("platformById/{platformId}")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int platformId)
        {
            Console.Write("Getting Platform by Id");
            var platform = _repository.GetPlatformById(platformId);
            if(platform != null)
                return Ok(_mapper.Map<PlatformReadDTO>(platform));
            else
                return  NotFound();
        }

        /// <summary>
        /// Create Platform and Return Platform Read DTO
        /// </summary>
        /// <param name="platformCreate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createplatform")]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreate)
        {
            Console.Write("Create Platform");
            var platformModel = _mapper.Map<Platform>(platformCreate);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
            //Get Converted CreatedDTO to ReadDTO and return
            var platformReadDto = _mapper.Map<PlatformReadDTO>(platformModel);
            Console.WriteLine(nameof(GetPlatformById));
            return CreatedAtRoute("platformById", new { platformId = platformReadDto.Id}, platformReadDto);
            //return Ok(platformReadDto);
        }


    }
}