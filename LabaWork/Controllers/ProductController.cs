using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ProductValidator _productValidator;
    private readonly CreateProduct _createProduct;
    private readonly ISectionService<Brand> _brandService;
    private readonly ISectionService<Category> _categoryService;

    public ProductController(
        IProductService productService, 
        ProductValidator productValidator, 
        CreateProduct createProduct,
        ISectionService<Brand> brandService, 
        ISectionService<Category> categoryService)
    {
        _productService = productService;
        _productValidator = productValidator;
        _createProduct = createProduct;
        _brandService = brandService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult AllProducts()
    {
        List<Product> products = _productService.GetAll();
        return View(products);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        GetBrandsAndCategories();
        return View(_createProduct);
    }
    
    [HttpPost]
    public IActionResult Create(Product? product)
    {
        if (product == null) return NotFound();

        var validResult = _productValidator.Validate(product);
        if (validResult.IsValid)
        {
            _productService.Add(product);
        }
        else
        {
            GetBrandsAndCategories();
            _createProduct.ErrorViewModel.Errors = validResult.Errors;
            return View(_createProduct); 
        }
        return RedirectToAction("AllProducts");
    }

    [NonAction]
    private void GetBrandsAndCategories()
    {
        _createProduct.Categories = _categoryService.GetAll();
        _createProduct.Brands = _brandService.GetAll();
    }
}