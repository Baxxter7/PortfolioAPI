using PortfolioAPI.Data.Entities;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data.Repositories;

public class ExperienceRepository
{
    private readonly ApplicationContext _context;

    public ExperienceRepository(ApplicationContext context)
    {
        _context = context;
    }
    public List<Experience> GetAll() => _context.Experiences.ToList();
    public List<Experience> GetByTitle(string title) => _context.Experiences.Where(e => e.Title.Contains(title)  && e.State == "Active").ToList() ;
    
    public int AddExperience(Experience experience)
    {
        _context.Experiences.Add(experience);
        _context.SaveChanges();
        return experience.Id;
    }
    public Experience? GetById(int id) => _context.Experiences.FirstOrDefault(experience => experience.Id == id);
    public void UpdateExperience(int id, ExperienceForCreationAndUpdateRequest requestDto)
    {
        Experience? entity =  GetById(id);
        if (entity == null) 
            throw new KeyNotFoundException($"No se encontró la experiencia con Id {id}.");
        
        entity.Title = requestDto.Title;
        entity.Description = requestDto.Description;
        entity.ImagePath = requestDto.ImagePath;
        
        _context.SaveChanges();
    }
    
    public void DeleteExperience(int id) 
    {
        var entity = GetById(id);
        if (entity == null)
            throw new KeyNotFoundException($"No se encontró la experiencia con Id {id}.");

        _context.Experiences.Remove(entity);
        _context.SaveChanges();
    }
}