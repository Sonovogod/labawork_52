using LabaWork.Models.Abstract;

namespace LabaWork.Models;

public class Category : ISection
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NormalizeName { get; set; }
}