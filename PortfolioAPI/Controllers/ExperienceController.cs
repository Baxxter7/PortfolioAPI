using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data.Repositories;
using PortfolioAPI.Entities;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        
        private readonly ExperienceRepository _repository;
        public ExperienceController(ExperienceRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Experience>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll().Where(e => e.State == "Active"));
        }
        
        /*
        [HttpGet("{titleForSearch}")]
        [ProducesResponseType(typeof(IEnumerable<Experience>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string titleForSearch)
        {
            return Ok(_repository.Experiences.Where(e => e.Title.Contains(titleForSearch)  && e.State == "Active"));
        }
        */

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

           _repository.AddExperience(entity);
           return Ok("Registro guardado exitosamente");
        }

        /*
        [HttpPut("{idExperience}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] int idExperience,  [FromBody]ExperienceForCreationAndUpdateRequest requestDto)
        {
            var entityId = _repository.Experiences.FindIndex(e => e.Id == idExperience);
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
                Sumary = _repository.Experiences[entityId].Sumary
            };

            _repository.Experiences[entityId]  = newExperience;
            return Ok("Registro editado exitosamente");
        }

        [HttpDelete("{idExperience}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int idExperience)
        {
            var entityId = _repository.Experiences.FindIndex(e => e.Id == idExperience);
            if (entityId == -1)
            {
                return BadRequest("Experiencia no encontrada");
            }

            Experience deletedExperience = new Experience()
            {
                Id = idExperience,
                Description = _repository.Experiences[entityId].Description,
                Title = _repository.Experiences[entityId].Title,
                ImagePath = _repository.Experiences[entityId].ImagePath,
                Sumary = _repository.Experiences[entityId].Sumary,
                State = "Deleted"
            };

            _repository.Experiences[entityId]  = deletedExperience;
            return Ok("Registro eliminado exitosamente");
        }
    */
    }
}
