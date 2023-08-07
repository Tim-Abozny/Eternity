using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Eternity.DTO.DTOs
{
    public class WorkDTO
    {
        [Display(Name = "Фото работы")]
        [Required(ErrorMessage = "Ошибка: картинка не загружена")]
        public IFormFile Image { get; set; }
    }
}
