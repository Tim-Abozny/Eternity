using System.ComponentModel.DataAnnotations;

namespace Eternity.DataProvider.Models
{
    public class Key
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ошибка: Вы не указали новый ключ")]
        public string Text { get; set; }
    }
}
