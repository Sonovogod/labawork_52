using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class BrandController : Controller
{
    private readonly ISectionService<Brand> _brandService;
    private readonly BrandAndErrors _brandAndErrors;
    private readonly BrandValidator _brandValidator;

    public BrandController(ISectionService<Brand> brandService, BrandAndErrors brandAndErrors, BrandValidator brandValidator)
    {
        _brandService = brandService;
        _brandAndErrors = brandAndErrors;
        _brandValidator = brandValidator;
    }

    [HttpGet]
    public IActionResult CreateBrand()
    {
        return View(_brandAndErrors);
    }
    
    [HttpPost]
    public IActionResult CreateBrand(Brand? brand)
    {
        if (brand == null) return NotFound();
        
        var validResult = _brandValidator.Validate(brand);
        if (validResult.IsValid)
        {
            brand.NormalizeName = brand.Name.Trim().ToUpper();
            _brandService.Add(brand);
        }
        else
        {
            _brandAndErrors.ErrorViewModel.Errors = validResult.Errors;
            return View(_brandAndErrors);
        }
        
        return RedirectToAction("AllProducts", "Product");
    }
}