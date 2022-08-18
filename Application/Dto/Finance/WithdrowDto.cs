using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Finance
{
    public class WithdrowDto
    {
        [Required, MaxLength(499)]
        public string Description { get; set; }
        [Required, MaxLength(9)]
        public int Amount { get; set; }
    }
}