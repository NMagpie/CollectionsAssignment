namespace Repository;

using Entities;

public class ListRepository<T> : IRepository<T> where T : Entity
{

    protected readonly List<T> _list = [];

    public void Add(T entity)
    {
        _list.Add(entity);
    }

    public void Delete(int id)
    {
        _list.Remove(GetById(id));
    }

    public void DeleteAll()
    {
        _list.Clear();
    }

    public IList<T> GetAll()
    {

        return new List<T>(_list);
    }

    public T? GetById(int id)
    {
        foreach (T element in _list)
        {
            if (element.Id == id) return element;
        };

        return null;
    }

    public void Update(T entity)
    {
        var element = GetById(entity.Id);

        if (element != null)
            LocalUpdateByRef(ref element, ref entity);

        void LocalUpdateByRef(ref T element, ref T entity)
        {
            element = entity;
        }
    }
}