using System.ComponentModel.DataAnnotations;

namespace Eternity.DataProvider.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Название не указано")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Ошибка: Вы оставили пустое описание")]
        public string Description { get; set; }
    }
}
