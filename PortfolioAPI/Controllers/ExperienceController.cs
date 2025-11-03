using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data.Entities;
using PortfolioAPI.Data.Repositories;
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
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<Experience>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
        

        [HttpGet("{titleForSearch}")]
        [ProducesResponseType(typeof(IEnumerable<Experience>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string titleForSearch)
        {
            return Ok(_repository.GetByTitle(titleForSearch));
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

           _repository.AddExperience(entity);
           return Ok("Registro guardado exitosamente");
        }


        [HttpPut("{idExperience}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] int idExperience,  [FromBody]ExperienceForCreationAndUpdateRequest requestDto)
        {
            _repository.UpdateExperience(idExperience, requestDto);
            return Ok("Registro editado exitosamente");
        }

        [HttpDelete("{idExperience}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int idExperience)
        {
            _repository.DeleteExperience(idExperience);
            return Ok("Registro eliminado exitosamente");
        }
    }
}
