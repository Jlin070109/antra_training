using hw3.Repositories;

namespace hw3;

// GenericRepository<T> class
public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Save()
    {
        // Simulate saving to a data source
        Console.WriteLine("Changes saved to data source.");
    }

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }
}