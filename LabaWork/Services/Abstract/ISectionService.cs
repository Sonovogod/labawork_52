namespace LabaWork.Services.Abstract;

public interface ISectionService <T>
{
    public List<T> GetAll();
    public T? GetById(int id);
    public void Create(T? section);
    public void Delete(T? section);
}