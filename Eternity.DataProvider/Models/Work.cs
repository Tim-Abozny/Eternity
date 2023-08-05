using System.ComponentModel.DataAnnotations;

namespace Eternity.DataProvider.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ошибка: фото работы не было загружено")]
        public byte[] WorkImage { get; set; }
    }
}
