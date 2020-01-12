using System.ComponentModel.DataAnnotations;

namespace MPuzzleApi.Models
{
    public class Story
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Title { get; set; }
        [StringLength(200)]
        [Required]
        public string Question { get; set; }
        [StringLength(500)]
        [Required]
        public string Answer { get; set; }

    }
}
