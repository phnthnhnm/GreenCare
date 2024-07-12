using System.ComponentModel.DataAnnotations;

namespace api.Helpers
{
    public enum PaymentMethod
    {
        [Display(Name = "Card")]
        Card,
        [Display(Name = "Cash")]
        Cash
    }
}
