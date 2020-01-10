using System.ComponentModel.DataAnnotations;

namespace ChartChecker.Models.Database
{
    public class SingleRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Artist { get; set; }
    }
}
