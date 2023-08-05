using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Eternity.DTO.DTOs
{
    public class PriceDTO
    {
        [Required(ErrorMessage = "Название не указано")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Ошибка: Вы оставили пустое описание")]
        public string Description { get; set; }
    }
}
