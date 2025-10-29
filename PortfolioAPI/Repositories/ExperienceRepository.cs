using PortfolioAPI.Entities;

namespace PortfolioAPI.Repositories;

public class ExperienceRepository
{
    public ExperienceRepository(){ }
    public List<Experience> Experiences { get; set; } = new List<Experience>{
            new Experience()
            {
                Id = 1,
                Title = "Experience 1",
                Description = "",
                ImagePath = "gadsas",
                Sumary = "hdsofhasldf"
            },
            new Experience()
            {
                Id = 2,
                Title = "Experience 2",
                Description = "fdsfsd",
                ImagePath = "gadsas",
                Sumary = "hdsofhasldf"
            },
            new Experience()
            {
                Id = 3,
                Title = "Programador Backend",
                Description = "",
                ImagePath = "gadsas",
                Sumary = "hdsofhasldf"
            }
        };
    public void AddExperience(Experience experience)
    {
        Experiences.Add(experience);
    }
}