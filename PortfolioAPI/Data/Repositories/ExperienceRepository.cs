using PortfolioAPI.Entities;

namespace PortfolioAPI.Data.Repositories;

public class ExperienceRepository
{
    private readonly ApplicationContext _context;

    public ExperienceRepository(ApplicationContext context)
    {
        _context = context;
    }
    public List<Experience> GetAll() => _context.Experiences.ToList();
    
    public int AddExperience(Experience experience)
    {
        _context.Experiences.Add(experience);
        _context.SaveChanges();
        return experience.Id;
    }
}