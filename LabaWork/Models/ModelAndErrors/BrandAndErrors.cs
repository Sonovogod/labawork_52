namespace LabaWork.Models.ModelAndErrors;

public class BrandAndErrors
{
    public ErrorViewModel ErrorViewModel { get; set; }
    public Brand Brand { get; set; }

    public BrandAndErrors()
    {
        ErrorViewModel = new ErrorViewModel();
    }
}