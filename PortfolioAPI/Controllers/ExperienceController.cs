using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Entities;
using PortfolioAPI.Models;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Experience>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return Ok(ExperienceRepository.Experiences.Where(e => e.State == "Active"));
        }

        [HttpGet("{titleForSearch}")]
        [ProducesResponseType(typeof(IEnumerable<Experience>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string titleForSearch)
        {
            return Ok(ExperienceRepository.Experiences.Where(e => e.Title.Contains(titleForSearch)  && e.State == "Active"));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddExperience([FromBody] ExperienceForCreationAndUpdateRequest experienceDto)
        {
            Experience entity = new Experience
            {
                Title = experienceDto.Title,
                Description = experienceDto.Description,
                ImagePath = experienceDto.ImagePath,
                Sumary = "En proceso"
            };
            
           ExperienceRepository.AddExperience(entity);
            return Ok("Registro guardado exitosamente");
        }

        [HttpPut("{idExperience}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] int idExperience,  [FromBody]ExperienceForCreationAndUpdateRequest requestDto)
        {
            var entityId = ExperienceRepository.Experiences.FindIndex(e => e.Id == idExperience);
            if (entityId == -1)
            {
                return NotFound();
            }

            Experience newExperience = new Experience()
            {
                Id = idExperience,
                Description = requestDto.Description,
                Title = requestDto.Title,
                ImagePath = requestDto.ImagePath,
                Sumary = ExperienceRepository.Experiences[entityId].Sumary
            };
            
            ExperienceRepository.Experiences[entityId]  = newExperience;
            return Ok("Registro editado exitosamente");
        }

        [HttpDelete("{idExperience}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int idExperience)
        {
            var entityId = ExperienceRepository.Experiences.FindIndex(e => e.Id == idExperience);
            if (entityId == -1)
            {
                return BadRequest("Experiencia no encontrada");
            }
            
            Experience deletedExperience = new Experience()
            {
                Id = idExperience,
                Description = ExperienceRepository.Experiences[entityId].Description,
                Title = ExperienceRepository.Experiences[entityId].Title,
                ImagePath = ExperienceRepository.Experiences[entityId].ImagePath,
                Sumary = ExperienceRepository.Experiences[entityId].Sumary,
                State = "Deleted"
            };
                
            ExperienceRepository.Experiences[entityId]  = deletedExperience;
            return Ok("Registro eliminado exitosamente");
        }
    }
}
