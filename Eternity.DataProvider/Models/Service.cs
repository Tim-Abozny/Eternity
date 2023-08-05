using System.ComponentModel.DataAnnotations;

namespace Eternity.DataProvider.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Требуется название услуги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ошибка: Требуется загрузить фото услуги")]
        public byte[] ServicePhoto { get; set; }
    }
}
