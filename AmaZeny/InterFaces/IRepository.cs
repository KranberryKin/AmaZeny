using System.Collections.Generic;

namespace AmaZeny.InterFaces
{
  public interface IRepository<T>
  {
    /// <summary>
    /// Get all items from database amd returns an list.
    /// </summary>
    List<T> Get();
    /// <summary>
    /// Get single item by its id from database, and returns it.
    /// </summary>
    T Get(int id);
    /// <summary>
    /// Adds the item to the database, and returns it with it's Id.
    /// </summary>
    T Create(T data);
    /// <summary>
    /// Takes items updated data and find item in database, and updates it's values.
    /// </summary>
    T Edit(int id, T data);
    /// <summary>
    /// Removes items from database by its id.
    /// </summary>
    void Delete(int id);
  }
}