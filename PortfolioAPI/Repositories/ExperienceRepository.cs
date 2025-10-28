using PortfolioAPI.Entities;

namespace PortfolioAPI.Repositories;

public static class ExperienceRepository
{
    public static List<Experience> Experiences { get; set; } = new List<Experience>{
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
    public static void AddExperience(Experience experience)
    {
        Experiences.Add(experience);
    }
}