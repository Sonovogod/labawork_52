using LabaWork.Models.Abstract;

namespace LabaWork.Models.ModelAndErrors;

public class SectionAndErrors
{
    public ErrorViewModel ErrorViewModel { get; set; }
    public ISection Section { get; set; }

    public SectionAndErrors()
    {
        ErrorViewModel = new ErrorViewModel();
    }
}