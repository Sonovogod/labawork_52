using LabaWork.Models;
using LabaWork.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LabaWork.Services;

public class ProductService : IProductService
{
    private readonly ProductContext _db;

    public ProductService(ProductContext db)
    {
        _db = db;
    }


    public List<Product> GetAll()
    {
        var products = _db.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .ToList();

        return products;
    }

    public Product? GetById(int id) 
        => _db.Products.FirstOrDefault(x => x.Id == id);


    public void CreateProduct(Product? product)
    {
        if (product == null) return;
        _db.Products.Add(product);
        _db.SaveChanges();
    }

    public void EditProduct(Product? product)
    {
        if (product == null) return;
        _db.Products.Update(product);
        _db.SaveChanges();
    }

    public void DeleteProduct(Product? product)
    {
        if (product == null) return;
        _db.Products.Remove(product);
        _db.SaveChanges();
    }
}