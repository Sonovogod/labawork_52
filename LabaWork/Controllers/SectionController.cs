using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class SectionController : Controller
{
    private readonly ISectionService<Category> _categoryService;
    private readonly ISectionService<Brand> _brandService;
    private readonly SectionValidator _sectionValidator;
    private readonly SectionAndErrors _sectionAndErrors;

    public SectionController(ISectionService<Category> categoryService, SectionValidator sectionValidator, SectionAndErrors sectionAndErrors, ISectionService<Brand> brandService)
    {
        _categoryService = categoryService;
        _sectionValidator = sectionValidator;
        _sectionAndErrors = sectionAndErrors;
        _brandService = brandService;
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View(_sectionAndErrors);
    }
    
    [HttpPost]
    public IActionResult CreateCategory(Category? category)
    {
        if (category == null) return NotFound();
        
        var validResult = _sectionValidator.Validate(category);
        if (validResult.IsValid)
        {
            category.NormalizeName = category.Name.Trim().ToUpper();
            _categoryService.Add(category);
        }
        else
        {
            _sectionAndErrors.ErrorViewModel.Errors = validResult.Errors;
            return View(_sectionAndErrors);
        }
        
        return View(_sectionAndErrors);
    }
    
    [HttpGet]
    public IActionResult CreateBrand()
    {
        return View(_sectionAndErrors);
    }
    
    [HttpPost]
    public IActionResult CreateBrand(Brand? brand)
    {
        if (brand == null) return NotFound();
        
        var validResult = _sectionValidator.Validate(brand);
        if (validResult.IsValid)
        {
            brand.NormalizeName = brand.Name.Trim().ToUpper();
            _brandService.Add(brand);
        }
        else
        {
            _sectionAndErrors.ErrorViewModel.Errors = validResult.Errors;
            return View(_sectionAndErrors);
        }
        
        return View(_sectionAndErrors);
    }
}