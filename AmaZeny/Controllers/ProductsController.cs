using System.Collections.Generic;
using System.Threading.Tasks;
using AmaZeny.Models;
using AmaZeny.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;

namespace AmaZeny.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _ps;

    public ProductsController(ProductsService ps)
    {
      _ps = ps;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] Product data)
    {
      try
      {
           Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
           data.OwnerId = userInfo.Id;
           var product = _ps.Create(data);
           return Ok(product);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async void Delete(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          var foundProduct = _ps.Get(id);
          if (foundProduct.OwnerId != userInfo.Id)
          {
            throw new System.Exception("You Can't Do That!");
          }
           _ps.Delete(id);
           Ok("DeYEETed");
      }
      catch (System.Exception e)
      {
          BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> Edit(int id, [FromBody] Product data)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          var foundProduct = _ps.Get(id);
          if (foundProduct.OwnerId != userInfo.Id)
          {
            throw new System.Exception("You Can't Do That!");
          }
          data.OwnerId = userInfo.Id;
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