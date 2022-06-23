namespace Utilities.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public enum StringExtensionsFormats
    {
        [Display(Name = "MM/dd/yyyy")]
        MMddYYYY,
        [Display(Name = "MM/dd/yyyy HH:mm")]
        MMddyyyyHHmm,
        [Display(Name = "MM/dd/yyyy hh:mm tt")]
        MMddyyyyHHmmtt
    }
}