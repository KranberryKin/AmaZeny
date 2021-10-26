namespace AmaZeny.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string OwnerId { get; set; }
    public Profile Owner { get; set; }
  }
}