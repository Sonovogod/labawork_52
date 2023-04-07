using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ProductValidator _productValidator;

    public ProductController(IProductService productService, ProductValidator productValidator)
    {
        _productService = productService;
        _productValidator = productValidator;
    }

    [HttpGet]
    public IActionResult AllProducts()
    {
        var products = _productService.GetAll();
        return View(products);
    }
    
}