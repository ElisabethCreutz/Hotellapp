using FluentValidation;
using HotelEC.Models.RoomModels;

namespace HotelEC.Controllers
{
    public class RoomValidator:AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(room => room.Floor).NotEmpty().WithMessage("Våning är obligatoriskt.");
            RuleFor(room => room.RoomType).NotEmpty().WithMessage("Rumstyp är obligatoriskt.");
        }
    }
}