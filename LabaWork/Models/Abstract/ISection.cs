namespace LabaWork.Models.Abstract;

public interface ISection
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NormalizeName { get; set; }
}