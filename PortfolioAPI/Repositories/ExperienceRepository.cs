using PortfolioAPI.Entities;

namespace PortfolioAPI.Repositories;

public class ExperienceRepository
{
    public List<Experience> Experiences { get; set; }

    public ExperienceRepository()
    {
        Experiences = new List<Experience>()
        {
            new Experience()
            {
                Title = "Experience 1",
                Description = "",
                ImagePath = "gadsas",
                Sumary = "hdsofhasldf"
            },
            new Experience()
            {
                Title = "Experience 2",
                Description = "",
                ImagePath = "gadsas",
                Sumary = "hdsofhasldf"
            },
            new Experience()
            {
                Title = "Programador Backend",
                Description = "",
                ImagePath = "gadsas",
                Sumary = "hdsofhasldf"
            }
        };
    }
}