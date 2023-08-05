using System.ComponentModel.DataAnnotations;

namespace Eternity.DataProvider.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ошибка: Вы не указали описание \"О нас\"")]
        public string Text { get; set; }
    }
}
