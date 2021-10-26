using System.Collections.Generic;
using AmaZeny.InterFaces;
using AmaZeny.Models;
using AmaZeny.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZeny.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase, IController<Product>
  {
    private readonly ProductsService _ps;

    public ProductsController(ProductsService ps)
    {
      _ps = ps;
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product data)
    {
      try
      {
           var product = _ps.Create(data);
           return Ok(product);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      try
      {
           _ps.Delete(id);
           Ok("DeYEETed");
      }
      catch (System.Exception e)
      {
          BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Edit(int id, [FromBody] Product data)
    {
      try
      {
           var product = _ps.Edit(id, data);
           return Ok(product);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Product>> Get()
    {
      try
      {
           var products = _ps.Get();
           return Ok(products);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      try
      {
           var product = _ps.Get(id);
           return Ok(product);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }

}