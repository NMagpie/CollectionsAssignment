namespace Repository;

using Entities;

public interface IRepository<T> where T: Entity
{
    T? GetById(int id);
    IList<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    void DeleteAll();
}