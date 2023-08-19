using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Eternity.DTO.DTOs
{
    public class ServiceDTO
    {
        [Display(Name = "Название услуги")]
        [Required(ErrorMessage = "Требуется название услуги")]
        public string Name { get; set; }
        [Display(Name = "Фото услуги")]
        [Required(ErrorMessage = "Ошибка: Требуется загрузить фото услуги")]
        public IFormFile ServicePhoto { get; set; }
    }
}
