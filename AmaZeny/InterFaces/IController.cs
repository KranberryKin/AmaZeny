using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AmaZeny.InterFaces
{
  public interface IController<T>
  {
    /// <summary>
    /// Get all items from database amd returns an list.
    /// </summary>
    ActionResult<List<T>> Get();
    /// <summary>
    /// Get single item by its id from database, and returns it.
    /// </summary>
    ActionResult<T> Get(int id);
    /// <summary>
    /// Adds the item to the database, and returns it with it's Id.
    /// </summary>
    ActionResult<T> Create([FromBody] T data);
    /// <summary>
    /// Takes items updated data and find item in database, and updates it's values.
    /// </summary>
    ActionResult<T> Edit(int id, [FromBody] T data);
    /// <summary>
    /// Removes items from database by its id.
    /// </summary>
    void Delete(int id);
  }
}