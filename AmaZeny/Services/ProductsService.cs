using System.Collections.Generic;
using AmaZeny.InterFaces;
using AmaZeny.Models;
using AmaZeny.Repositories;

namespace AmaZeny.Services
{
  public class ProductsService : IService<Product>
  {
    private readonly ProductsRepository _pr;

    public ProductsService(ProductsRepository pr)
    {
      _pr = pr;
    }

    public Product Create(Product data)
    {
      return _pr.Create(data);
    }

    public void Delete(int id)
    {
       _pr.Delete(id);
    }

    public Product Edit(int id, Product data)
    {
      var product = Get(id);
      data.Id = product.Id;
      return _pr.Edit(data);
    }

    public List<Product> Get()
    {
      return _pr.Get();
    }

    public Product Get(int id)
    {
      return _pr.Get(id);
    }
  }
}