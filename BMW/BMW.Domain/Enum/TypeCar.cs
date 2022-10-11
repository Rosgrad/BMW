using System.ComponentModel.DataAnnotations;

namespace BMW.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Внедорожник")]
        Offroader = 0,
        [Display(Name = "Седан")]
        Sedan = 0,
        [Display(Name = "Хэтчбек")]
        Hatchback = 0,
    }
}
