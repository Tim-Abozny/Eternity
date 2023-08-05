using System.ComponentModel.DataAnnotations;

namespace Eternity.DTO.DTOs
{
    public class ServiceDTO
    {
        [Required(ErrorMessage = "Требуется название услуги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ошибка: Требуется загрузить фото услуги")]
        public byte[] ServicePhoto { get; set; }
    }
}
