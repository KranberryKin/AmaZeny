using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZeny.InterFaces;
using AmaZeny.Models;
using Dapper;

namespace AmaZeny.Repositories
{
  public class ProductsRepository : IRepository<Product>
  {
  private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Product Create(Product data)
    {
      string sql = @"
      INSERT INTO products(name, price, ownerId) VALUES(@Name, @Price, @OwnerId);
      SELECT LAST_INSERT_ID;
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @id;";
      _db.Execute(sql); 
    }

    public Product Edit(Product data)
    {
      string sql = @"
      UPDATE products
      SET
      name = @Name
      price = @Price,
      ownerId = @OwnerId
      WHERE id = @id;
      ";
      var rowsAffected = _db.Execute(sql, data);
      if(rowsAffected == 0)
      {
        throw new Exception("Update failed...");
      }
      return data;
    }

    public Product Edit(int id, Product data)
    {
      throw new NotImplementedException();
    }

    public List<Product> Get()
    {
      string sql = "SELECT * FROM products;";
      return _db.Query<Product>(sql).ToList();
    }

    public Product Get(int id)
    {
      string sql = @"
      SELECT
       p.*,
       a.*
       FROM products p
       JOIN accounts a ON a.id = p.ownerId
       WHERE p.id = @id;";
      return _db.Query<Product, Account, Product>(sql, (p, a) =>
      {
        p.Owner = a;
        return p;
      }, new {id}).FirstOrDefault();
    }
  }
}
