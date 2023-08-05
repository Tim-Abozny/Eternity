using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Eternity.DTO.DTOs
{
    public class WorkDTO
    {
        [Display(Name = "Фото работы")]
        [Required(ErrorMessage = "")]
        public IFormFile Image { get; set; }
    }
}
