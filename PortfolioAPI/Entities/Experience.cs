namespace PortfolioAPI.Entities;

public class Experience
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Sumary { get; set; }
    public string ImagePath { get; set; }
    public string State { get; set; } = "Active";
}